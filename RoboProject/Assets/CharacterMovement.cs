using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _jumpHeight;

    private Rigidbody _rigidbody;


    [SerializeField]
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ManageKeyboardControls();
	}

    void ManageKeyboardControls()
    {
        // Moving horizontal

        float characterMagnitude = Input.GetAxis("Horizontal") * _movementSpeed;

        _rigidbody.AddForce(Vector3.right * characterMagnitude);
        _animator.SetFloat("MoveSpeed", characterMagnitude);

        // Moving Vertical
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _jumpHeight);
        }
    }
}
