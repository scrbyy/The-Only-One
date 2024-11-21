using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxJumpCount;

    private Rigidbody _rigidBody;
    private float _jumpCount;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _jumpCount = _maxJumpCount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0)
        {
            _rigidBody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
            _jumpCount--;
        }

        if (_rigidBody.velocity.y == 0 && _jumpCount == 0)
        {
            _jumpCount = _maxJumpCount;
        }
    }
}
