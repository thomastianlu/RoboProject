using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public static CameraShake instance = null;

    [SerializeField]
    private float _currentIntensity;
    private float _startingIntensity;
    [SerializeField]
    private float _duration;
    private float _startingDuration;
    private Vector3 _randomPosition;

    [SerializeField]
    private Vector3 _startingPosition;

    void Awake()
    {
        _startingPosition = transform.localPosition;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageShake();
    }

    void ManageShake()
    {
        if (_duration > 0)
        {
            _duration -= Time.deltaTime;
            _currentIntensity = _startingIntensity * Mathf.Abs(_duration / _startingDuration);

            transform.localPosition = Vector3.Lerp(transform.localPosition, _randomPosition, 1f);

            if (transform.localPosition == _randomPosition && _currentIntensity > 0)
            {
                GetNewCameraPosition(_currentIntensity);
            }

        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _startingPosition, 1f);
            _currentIntensity = 0;
        }
    }

    public void StartShake(float intensity, float duration)
    {
        if (_currentIntensity <= intensity)
        {
            _currentIntensity = intensity;
            _duration = duration;
            _startingDuration = duration;
            _startingIntensity = intensity;

            _randomPosition = _startingPosition 
                              + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) 
                              * _currentIntensity;
        }
        _currentIntensity = intensity;
    }

    void GetNewCameraPosition(float currentIntensity)
    {
        _randomPosition = _startingPosition 
                          + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) 
                          * currentIntensity;
    }
}
