using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float _sensetivity;
    [SerializeField] private float _sensetivityMultiplier;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private Transform _playerTransform;
    private float xRotation = 0f;

    private void Start()
    {
        CursorLocker.DisableCursor();
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetivity * _sensetivityMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetivity;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, _minAngle, _maxAngle);
        _playerTransform.Rotate(Vector3.up * mouseX);
        this.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
