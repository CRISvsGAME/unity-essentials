using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Renderer _renderer;
    private Material _material;
    private Color _baseEmission;
    private Color _glowEmission;

    [SerializeField] private float _glowIntensity = 2f;
    [SerializeField] private Color _glowColor = Color.white;
    [SerializeField] private float _fadeDuration = 1f;
    private Coroutine _fadeCoroutine;
    private float _fadeTimer;

    void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _material = _renderer.material;
        _material.EnableKeyword("_EMISSION");
        _baseEmission = _material.GetColor("_EmissionColor");
        _glowEmission = _glowColor * _glowIntensity;
    }

    public void OnLookEnter()
    {
        Fade(1f);
    }

    public void OnLookExit()
    {
        Fade(0f);
    }

    private void Fade(float target)
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
            _fadeCoroutine = null;
        }

        _fadeCoroutine = StartCoroutine(FadeEmission(target));
    }

    private IEnumerator FadeEmission(float target)
    {
        while (_fadeTimer != target)
        {
            _fadeTimer = Mathf.MoveTowards(_fadeTimer, target, Time.deltaTime / _fadeDuration);
            _material.SetColor("_EmissionColor", Color.Lerp(_baseEmission, _glowEmission, _fadeTimer));

            yield return null;
        }

        _fadeCoroutine = null;
    }
}
