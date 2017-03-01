using UnityEngine;
using System.Collections;

public class MovingTileScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        MoveBlock();
	}

    void MoveBlock()
    {
        if (GameManager.instance.bossIsWalking)
        {
            transform.position += Vector3.left 
                                  * GameManager.instance.platformMoveSpeed 
                                  * Time.deltaTime;
        }
    }
}
