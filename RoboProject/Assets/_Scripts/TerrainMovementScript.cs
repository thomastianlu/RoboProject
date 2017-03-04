using UnityEngine;
using System.Collections;

// Terrain Movement Script
// This script enables terrain to move towards the left

public class TerrainMovementScript : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        float platformMovementSpeed = GameManager.instance.bossIsWalking ?
                                      GameManager.instance.platformMoveSpeed * Time.deltaTime : 0;

        transform.position -= Vector3.right * platformMovementSpeed;
	}
}
