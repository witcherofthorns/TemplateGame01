using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera currentCamera;
    [Header("Zoom Scroll")]
    [SerializeField] private float zoomMaxValue;
    [SerializeField] private float zoomMinValue;
    [SerializeField,Range(0.1f,1.0f)] private float zoomingValue;
    [Header("Look At")]
    [SerializeField, Range(0.1f, 1.0f)] private float lookMovementSpeed;
    [SerializeField] private Vector3 lookOffset;
    private Transform targetLookAt;

    public Camera CurrentCamera { get => currentCamera; }

    private void FixedUpdate()
    {
        CameraLookAt();
    }

    public void ZoomIn()
    {
        if ((currentCamera.orthographicSize - zoomingValue) >= zoomMinValue)
        {
            currentCamera.orthographicSize -= zoomingValue;
        }
    }

    public void ZoomOut()
    {
        if((currentCamera.orthographicSize + zoomingValue) <= zoomMaxValue)
        {
            currentCamera.orthographicSize += zoomingValue;
        }
    }

    public void SetLookAt(Transform target)
    {
        targetLookAt = target;
    }


    private void CameraLookAt()
    {
        if (!targetLookAt)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, targetLookAt.position + lookOffset, lookMovementSpeed);
    }

    private void OnValidate()
    {
        if(!currentCamera)
        {
            TryGetComponent<Camera>(out currentCamera);
        }
    }
}