using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    private CharacterController _characterController;
    private Vector3 _moveDirection;

    public Vector3 GetDirection()
    {
        return _moveDirection;
    }
    private void Start()
    {
        _characterController = GetComponent<CharacterController>(); 
    }
    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * _walkSpeed;
        float vInput = Input.GetAxis("Vertical") * _walkSpeed;
        _moveDirection = new Vector3(hInput, 0, vInput);
        _moveDirection = transform.TransformVector(_moveDirection);
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
