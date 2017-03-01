using UnityEngine;
using System.Collections;

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
