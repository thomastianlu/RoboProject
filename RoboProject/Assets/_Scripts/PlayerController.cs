using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    [Header("Player Stats")][Space(5)]
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _jumpStrength;
    
    [Header("References")][Space(5)]
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private Transform _characterArt;
    private Vector3 _characterArtScale;

    private float _currentGravity;

	// Use this for initialization
	void Start ()
    {
        _currentGravity = _rigidBody.gravityScale;
        _characterArtScale = _characterArt.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        ManageHorizontalMovement();
        ManageVerticalMovement();
	}

    void ManageHorizontalMovement()
    {
        float platformMovementSpeed = GameManager.instance.bossIsWalking ? 
                                      GameManager.instance.platformMoveSpeed * Time.deltaTime : 0;

        float XAxismovement = (Input.GetAxis("Horizontal") * Time.deltaTime * _movementSpeed) - platformMovementSpeed;

        transform.position += new Vector3(XAxismovement
                                          , 0f
                                          , 0f);

        if (XAxismovement < 0)
        {
            _characterArt.localScale = new Vector3(_characterArtScale.x
                                                   , _characterArtScale.y
                                                   , _characterArtScale.z * -1);
        }
        else if (XAxismovement > 0)
        {
            _characterArt.localScale = new Vector3(_characterArtScale.x
                                                   , _characterArtScale.y
                                                   , _characterArtScale.z);
        }
    }

    void ManageVerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector2.up * _jumpStrength * _currentGravity);
        }
    }
}
