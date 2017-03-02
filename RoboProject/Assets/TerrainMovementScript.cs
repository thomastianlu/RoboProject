using UnityEngine;
using System.Collections;

public class TerrainMovementScript : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        float platformMovementSpeed = GameManager.instance.bossIsWalking ?
                                      GameManager.instance.platformMoveSpeed * Time.deltaTime : 0;

        transform.position -= new Vector3(platformMovementSpeed
                                          , 0f
                                          , 0f);
	}
}
