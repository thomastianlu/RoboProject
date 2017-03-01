using UnityEngine;
using System.Collections;

public class BossAttackPattern : MonoBehaviour {

    private enum Attacks
    {
        Punch,
        Jump
    }
    
    [Header("Attack Stats")][Space(5)]
    [SerializeField]
    private float _jumpForwardMagnitude;
    
    [Header("References")][Space(5)]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Animator _warningAnimator;

    [SerializeField]
    private float _timeToNextPattern;
    private float _timeToNextPatternReset;

    private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
        _timeToNextPatternReset = _timeToNextPattern;
        _startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        ManageAttackPatterns();
	}

    void ManageAttackPatterns()
    {
        // Timer waiting for the next attack
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            _timeToNextPattern -= Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition
                                                          , _startPosition
                                                          , GameManager.instance.platformMoveSpeed * 2f * Time.deltaTime);
        }

        if (_timeToNextPattern < 0)
        {
            ChooseRandomAttack();
        }

        // Manage positions for when the animation gets into a different state
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            transform.position -= new Vector3(GameManager.instance.platformMoveSpeed * Time.deltaTime
                                             , 0f
                                             , 0f);
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition
                                                          , _startPosition + Vector3.forward * _jumpForwardMagnitude
                                                          , GameManager.instance.platformMoveSpeed * 2f * Time.deltaTime);
        }
    }

    void ChooseRandomAttack()
    {
        int randomAttackIterator = Random.Range(0, 2);

        switch ((Attacks)randomAttackIterator)
        {
            case Attacks.Jump:
                _animator.SetFloat("MoveSpeed", 0F);
                _warningAnimator.Play("WarningJump");
                break;
            case Attacks.Punch:
                _animator.SetBool("IsPunching", true);
                _warningAnimator.Play("WarningPunch");
                break;
        }

        // The faster the platforms move, the more frequent the attacks
        _timeToNextPattern = _timeToNextPatternReset - GameManager.instance.platformMoveSpeed;
    }

    // Called from the animation - resets the variables after the attack
    void ResetToWalking()
    {
        _animator.SetFloat("MoveSpeed", 5F);
        _animator.SetBool("IsPunching", false);
    }
}
