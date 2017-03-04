using UnityEngine;
using System.Collections;

// Player Controller Script
// This is the player controller - it carries the code that translate the input into movement
// It also manages the death of the player when he/she hits the boss

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
    [SerializeField]
    private PlayerGroundDetector _playerGroundDetector;

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
        ManageJumping();
	}

    void ManageHorizontalMovement()
    {
        // Get the platform movement speed - if the boss is walking, set the speed, if not, set to 0
        float platformMovementSpeed = GameManager.instance.bossIsWalking ? 
                                      GameManager.instance.platformMoveSpeed * Time.deltaTime : 0;

        float XAxismovement = (Input.GetAxis("Horizontal") * Time.deltaTime * _movementSpeed) - platformMovementSpeed;

        transform.position += Vector3.right * XAxismovement;

        // Calculates which direction the player is facing and faces the player art accordingly
        if (XAxismovement + platformMovementSpeed < 0)
        {
            _characterArt.localScale = new Vector3(_characterArtScale.x
                                                   , _characterArtScale.y
                                                   , _characterArtScale.z * -1);
        }
        else if (XAxismovement + platformMovementSpeed > 0)
        {
            _characterArt.localScale = new Vector3(_characterArtScale.x
                                                   , _characterArtScale.y
                                                   , _characterArtScale.z);
        }
    }

    void ManageJumping()
    {
        // Triggers the jump
        if (Input.GetKeyDown(KeyCode.W) & _playerGroundDetector.isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * _jumpStrength * _currentGravity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Trigger Player Death
        if (other.CompareTag("Boss") || other.CompareTag("BossProjectile"))
        {
            GameManager.instance.playerHasDied = true;

            AudioManager audioManager = AudioManager.instance;
            audioManager.PlayAudioParameter(audioManager.explosion);

            gameObject.SetActive(false);
        }
    }
}
