using UnityEngine;

public class DesiredSizeTool : MonoBehaviour
{
    [SerializeField]
    private Vector3 _desiredSize = Vector3.one;

    public void Apply()
    {
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();

        if (!meshFilter)
        {
            Debug.LogWarning("MeshFilter Not Found!");
            return;
        }

        Vector3 meshSize = meshFilter.sharedMesh.bounds.size;

        Vector3 requiredScale = new(
            _desiredSize.x / meshSize.x,
            _desiredSize.y / meshSize.y,
            _desiredSize.z / meshSize.z
        );

        transform.localScale = requiredScale;
    }
}
