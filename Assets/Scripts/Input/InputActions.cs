using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset _inputActions;
    private InputActionMap _playerActionMap;
    private InputAction _lookAction;
    private InputAction _moveAction;
    private InputAction _verticalAction;

    [SerializeField]
    private float _sensitivity = 10f;
    private float _xRotation = 0f;
    private float _yRotation = 0f;

    [SerializeField]
    private float _moveSpeed = 10f;

    [SerializeField]
    private bool _movementClamp = false;

    [SerializeField]
    private Vector3 _minBounds = new(-15f, 1f, -15f);

    [SerializeField]
    private Vector3 _maxBounds = new(15f, 30f, 15f);

    private void Awake()
    {
        _playerActionMap = _inputActions.FindActionMap("Player");
        _lookAction = _playerActionMap.FindAction("Look");
        _moveAction = _playerActionMap.FindAction("Move");
        _verticalAction = _playerActionMap.FindAction("Vertical");
    }

    private void OnEnable()
    {
        _playerActionMap.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        _playerActionMap.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        Vector2 lookDelta = _lookAction.ReadValue<Vector2>();
        _xRotation -= lookDelta.y * _sensitivity * Time.deltaTime;
        _yRotation += lookDelta.x * _sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);

        Vector2 m = _moveAction.ReadValue<Vector2>();
        float v = _verticalAction.ReadValue<float>();

        Vector3 direction = transform.forward * m.y + transform.right * m.x + transform.up * v;

        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }

        Vector3 position = _moveSpeed * Time.deltaTime * direction + transform.position;

        if (_movementClamp)
        {
            position.x = Mathf.Clamp(position.x, _minBounds.x, _maxBounds.x);
            position.y = Mathf.Clamp(position.y, _minBounds.y, _maxBounds.y);
            position.z = Mathf.Clamp(position.z, _minBounds.z, _maxBounds.z);
        }

        transform.position = position;
    }
}
