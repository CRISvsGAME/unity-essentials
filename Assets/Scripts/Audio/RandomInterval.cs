using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomInterval : MonoBehaviour
{
    [SerializeField] private float _minSeconds = 5f;
    [SerializeField] private float _maxSeconds = 15f;

    private AudioSource _audioSource;
    private Coroutine _audioCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _minSeconds = Mathf.Max(0f, _minSeconds);
        _maxSeconds = Mathf.Max(_minSeconds + 1f, _maxSeconds);
    }

    private void OnEnable()
    {
        _audioCoroutine = StartCoroutine(PlaySound());
    }

    private void OnDisable()
    {
        if (_audioCoroutine != null)
        {
            StopCoroutine(_audioCoroutine);
            _audioCoroutine = null;
        }
    }

    private IEnumerator PlaySound()
    {
        while (true)
        {
            float waitTime = Random.Range(_minSeconds, _maxSeconds);
            yield return new WaitForSeconds(waitTime);
            _audioSource.Play();
        }
    }
}
