using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Length of a full day")]
    private float _dayLengthInSeconds = 60f;

    [Range(0f, 1f)]
    [SerializeField]
    [Tooltip("Starting time of day)")]
    private float _startTimeNormalized = 0.1f;

    [Range(0.1f, 0.9f)]
    [SerializeField]
    [Tooltip("Fraction of daytime cycle")]
    private float _daytimeFraction = 0.75f;

    private Vector3 _initialEuler;
    private float _timeOfDay;
    private float _nighttimeFraction;

    private void Awake()
    {
        _dayLengthInSeconds = Mathf.Max(10f, _dayLengthInSeconds);
        _initialEuler = transform.eulerAngles;
        _timeOfDay = _startTimeNormalized;
        _nighttimeFraction = 1f - _daytimeFraction;
    }

    void Start()
    {
        UpdateSunRotation();
    }

    void Update()
    {
        _timeOfDay += Time.deltaTime / _dayLengthInSeconds;

        if (_timeOfDay > 1f)
            _timeOfDay -= 1f;

        UpdateSunRotation();
    }

    private void UpdateSunRotation()
    {
        float sunAngle;

        if (_timeOfDay < _daytimeFraction)
        {
            float t = _timeOfDay / _daytimeFraction;
            sunAngle = Mathf.Lerp(0f, 180f, t);
        }
        else
        {
            float t = (_timeOfDay - _daytimeFraction) / _nighttimeFraction;
            sunAngle = Mathf.Lerp(180f, 360f, t);
        }

        transform.rotation = Quaternion.Euler(sunAngle, _initialEuler.y, _initialEuler.z);
    }
}
