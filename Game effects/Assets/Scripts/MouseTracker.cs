using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _zOffset;
    
    private void LateUpdate()
    {
        if (_mainCamera is null) return;

        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = _zOffset;

        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
    }
}
