using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerWalk))]

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCount;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _mass;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float rayDistance;
    private Vector3 _verticalDirection;
    private CharacterController _characterController;
    private PlayerWalk _walk;

    private void Start()
    {
        _walk = GetComponent<PlayerWalk>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckGround();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _verticalDirection = _walk.GetDirection();
            _verticalDirection.y = _jumpForce;
            _characterController.Move(_verticalDirection * Time.deltaTime);
        }
        UseGravity();
    }
    private void CheckGround()
    {
        if (Physics.Raycast(this.transform.position, -Vector3.up, rayDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void UseGravity()
    {
        if (isGrounded == false)
        {
            _verticalDirection.y = _gravityScale * _mass;
            _characterController.Move(_verticalDirection * Time.deltaTime);

        }
    }
}
