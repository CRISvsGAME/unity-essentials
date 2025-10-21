using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField]
    private float _rayDistance = 5f;

    void Update()
    {
        Ray ray = new(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _rayDistance))
        {
            Debug.Log("Hit Object: " + hitInfo.collider.gameObject.name);
        }
    }
}
