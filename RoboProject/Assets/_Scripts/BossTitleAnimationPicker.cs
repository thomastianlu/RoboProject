﻿using UnityEngine;
using System.Collections;

// Boss Title Animation Script
// This script manages the animation for the boss on the title screen
// It does not play the walk animation on the title screen

public class BossTitleAnimationPicker : MonoBehaviour {

    [SerializeField]
    private Animator _animator;
    private float _timeToPickNewAnimation = 5f;
    private float _timeToPickNewAnimationReset;

	// Use this for initialization
	void Start () {
        _timeToPickNewAnimationReset = _timeToPickNewAnimation;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            _timeToPickNewAnimation -= Time.deltaTime;

            if (_timeToPickNewAnimation < 0)
            {
                _animator.SetInteger("AnimationPick", Random.Range(0, 6));
                _timeToPickNewAnimation = _timeToPickNewAnimationReset;
            }
        }
	}
}
