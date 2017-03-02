using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance = null;
    

    [System.Serializable]
    public struct AudioParameter
    {
        public AudioClip audioClip;
        [Range(0.0f, 1.0f)]
        public float volume;
        [Range(1,3)]
        public int priority;

        // For pitch variation
        [Range(0.0f, 2.0f)]
        public float pitchLow;
        [Range(0.0f, 2.0f)]
        public float pitchHigh;
    }

    [SerializeField]
    private SFXLayer[] _audioSourceLayer;

    public AudioParameter largeImpact;
    public AudioParameter smallImpact;
    public AudioParameter explosion;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudioParameter(AudioParameter audio)
    {
        // Possible pseudorandom code needed to shuffle the random picks a bit more
        PlayAudio(audio.audioClip
                 , audio.volume
                 , audio.priority
                 , _audioSourceLayer
                 , audio.pitchLow
                 , audio.pitchHigh);
    }

    void PlayAudio(AudioClip audioClip, float volume, int priority, SFXLayer[] AudioSources, float pitchLow, float pitchHigh)
    {
        // Find non-playing audio sources to play audio
        foreach (SFXLayer audioSource in AudioSources)
        {
            if (!audioSource.SoundIsCurrentlyPlaying())
            {
                audioSource.SetClip(audioClip, volume, priority, pitchLow, pitchHigh);
                return;
            }
        }

        // If there are no audio sources that are not-playing, find one that the current SFX can override
        foreach (SFXLayer audioSource in AudioSources)
        {
            if (audioSource.NewSoundClipIsHigherPriority(priority))
            {
                audioSource.SetClip(audioClip, volume, priority, pitchLow, pitchHigh);
                return;
            }
        }
    }
}
