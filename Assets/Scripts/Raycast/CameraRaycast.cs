using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 5f;

    private IInteractable _currentInteractable;

    void Update()
    {
        Ray ray = new(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _rayDistance))
        {
            IInteractable interactable = hitInfo.collider.GetComponentInParent<IInteractable>();

            if (interactable != _currentInteractable)
            {
                _currentInteractable?.OnLookExit();
                _currentInteractable = interactable;
                _currentInteractable?.OnLookEnter();
            }
        }
        else
        {
            _currentInteractable?.OnLookExit();
            _currentInteractable = null;
        }
    }
}
