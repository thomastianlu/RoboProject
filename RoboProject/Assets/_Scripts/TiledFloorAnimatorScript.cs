using UnityEngine;
using System.Collections;

// Tiled Floor Animator Script
// This script plays the idle animation of the object when the object explodes
// This is to return the object back into its Idle state when it is returned
// to the object pool

public class TiledFloorAnimatorScript : MonoBehaviour {

    [SerializeField]
    private GameObject _parent;
    [SerializeField]
    private Animator _animator;

    void ReturnToObjectPool()
    {
        _animator.Play("Idle");
        _parent.SetActive(false);
    }
}
