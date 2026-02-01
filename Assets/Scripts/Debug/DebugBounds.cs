using UnityEngine;

[ExecuteAlways]
public class DebugBounds : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        Debug.Log($"{name} Bounds | X: {_renderer.bounds.size.x:F10} Y: {_renderer.bounds.size.y:F10} Z: {_renderer.bounds.size.z:F10}");
    }
}
