using UnityEngine;
using System.Collections;

public class MovingTileScript : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MoveBlock();
	}

    void MoveBlock()
    {
        if (GameManager.instance.bossIsWalking)
        {
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
    }
}
