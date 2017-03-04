using UnityEngine;
using System.Collections;

// Ground Detector
// This script checks if the player is grounded
// This is needed for the jump functionality so that the player doesn't jump infinitely

public class PlayerGroundDetector : MonoBehaviour {

    private bool _isGrounded;
    public bool isGrounded { get { return _isGrounded; } }

	void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Tiles"))
        {
            _isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tiles"))
        {
            _isGrounded = false;
        }
    }
}
