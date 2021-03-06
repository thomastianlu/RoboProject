﻿using UnityEngine;
using System.Collections;

// Tile Reset Script
// This script "Destroys" the tile once it gets hit by the boss

public class TileResetScript : MonoBehaviour {

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _cameraShakeIntensityOnDeath;
    [SerializeField]
    private float _cameraShakeDurationOnDeath;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            //SendToObjectPool
            CameraShake.instance.StartShake(_cameraShakeIntensityOnDeath
                                            , _cameraShakeDurationOnDeath);
            AudioManager audioManager = AudioManager.instance;
            audioManager.PlayAudioParameter(audioManager.smallImpact);
            _animator.Play("DeathAnimation");
        }
    }
}
