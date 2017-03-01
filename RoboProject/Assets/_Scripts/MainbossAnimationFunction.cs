using UnityEngine;
using System.Collections;

public class MainbossAnimationFunction : MonoBehaviour {
    
    [Header("References")][Space(5)]
    private GameObject _punchCollider;
    
    [Header("Camera Shake Fields")][Space(5)]
    [SerializeField]
    private float _stepCameraShakeIntensity;
    [SerializeField]
    private float _stepCameraShakeDuration;

    [SerializeField]
    private float _jumpCameraShakeIntensity;
    [SerializeField]
    private float _jumpCameraShakeDuration;

    [SerializeField]
    private float _punchCameraShakeIntensity;
    [SerializeField]
    private float _punchCameraShakeDuration;

    void CameraShakeStep()
    {
        CameraShake.instance.StartShake(_stepCameraShakeIntensity
                                        , _stepCameraShakeDuration);
    }

    void BossIsWalking()
    {
        GameManager.instance.bossIsWalking = true;
    }

    void BossIsNotWalking()
    {
        GameManager.instance.bossIsWalking = false;
    }

    void CameraStartJumpLanding()
    {
        CameraShake.instance.StartShake(_jumpCameraShakeIntensity/3
                                        , _jumpCameraShakeDuration/3);
    }

    void CameraShakeJumpLanding()
    {
        CameraShake.instance.StartShake(_jumpCameraShakeIntensity
                                        , _jumpCameraShakeDuration);
    }

    void CameraShakePunch()
    {

    }
}
