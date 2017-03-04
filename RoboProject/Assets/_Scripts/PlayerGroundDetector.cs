using UnityEngine;
using System.Collections;

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
