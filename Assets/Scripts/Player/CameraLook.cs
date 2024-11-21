using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float _sensetivity;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _sensetivityMultiplier;
    [SerializeField] private Transform _playerTransform;
    private float xRotation = 0f;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetivity * _sensetivityMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetivity;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, _minAngle, _maxAngle);
        this.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        _playerTransform.Rotate(new Vector3(0, mouseX, 0));
    }
}
