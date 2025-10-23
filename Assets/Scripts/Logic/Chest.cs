using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Renderer _renderer;
    private Material _material;
    private Color _baseEmission = Color.black;
    private Color _glowEmission = Color.yellow * 2f;

    void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _material = _renderer.material;
    }

    public void OnLookEnter()
    {
        _material.SetColor("_EmissionColor", _glowEmission);
    }

    public void OnLookExit()
    {
        _material.SetColor("_EmissionColor", _baseEmission);
    }
}
