using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    
    [Header("Character Stats")][Space(5)]
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _jumpHeight;

    private Rigidbody _rigidbody;

    // References
    [Header("References")][Space(5)]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GroundChecker _groundChecker;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ManageKeyboardControls();
        ManageAttack();
	}

    void ManageKeyboardControls()
    {
        // Moving horizontal

        float characterMagnitude = Input.GetAxis("Horizontal") * _movementSpeed;

        _rigidbody.AddForce(Vector3.right * characterMagnitude);
        _animator.SetFloat("MoveSpeed", characterMagnitude);

        // Moving Vertical
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.up * _jumpHeight);
            _animator.Play("Jump");
        }
    }

    void ManageAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.Play("NormalPunch");
        }
    }
}
