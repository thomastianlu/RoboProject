using UnityEngine;
using System.Collections;

public class SFXLayer : MonoBehaviour {

    [SerializeField]
    private AudioSource _audioSource;

    private int _currentClipPriority;

    public void SetPriority(int priority)
    {
        _currentClipPriority = priority;
    }

    public bool NewSoundClipIsHigherPriority(int priority)
    {
        return _currentClipPriority >= priority;
    }

    public bool SoundIsCurrentlyPlaying()
    {
        return _audioSource.isPlaying;
    }

    public void SetClip(AudioClip currentlyPlayingClip, float volume, int priority, float pitchLow, float pitchHigh)
    {
        _audioSource.clip = currentlyPlayingClip;
        _audioSource.pitch = Random.Range(pitchLow, pitchHigh);
        _audioSource.volume = volume;
        _audioSource.Play();
        _currentClipPriority = priority;
    }

    public void StopPlayingSound()
    {
        _audioSource.Stop();
    }
}
