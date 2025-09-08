using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset _inputActions;
    private InputActionMap _playerActionMap;
    private InputAction _lookAction;

    [SerializeField]
    private float _sensitivity = 100f;
    private float _xRotation = 0f;
    private float _yRotation = 0f;

    private void Awake()
    {
        _playerActionMap = _inputActions.FindActionMap("Player");
        _lookAction = _playerActionMap.FindAction("Look");
    }

    private void OnEnable()
    {
        _playerActionMap.Enable();
    }

    private void OnDisable()
    {
        _playerActionMap.Disable();
    }

    private void Update()
    {
        Vector2 lookDelta = _lookAction.ReadValue<Vector2>();
        _xRotation -= lookDelta.y * _sensitivity * Time.deltaTime;
        _yRotation += lookDelta.x * _sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}
