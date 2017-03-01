using UnityEngine;
using System.Collections;

public class TiledFloorAnimatorScript : MonoBehaviour {

    [SerializeField]
    private GameObject _parent;
	
    void ReturnToObjectPool()
    {
        _parent.SetActive(false);
    }
}
