using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumpCount;

    private Rigidbody _rigidBody;
    private int _jumpCount;
    private float _maxFallVelocity;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _jumpCount = _maxJumpCount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0)
        {
            _rigidBody.AddForce(_jumpForce * Vector3.up, ForceMode.VelocityChange);
            _jumpCount--;
        }
        TryUpdateFallDamage();
        if (_rigidBody.velocity.y == 0 && _jumpCount == 0)
        {
            _jumpCount = _maxJumpCount;
            TryGetFallDamage();
        }
       
    }
    private void TryGetFallDamage()
    {
        _maxFallVelocity = 0f;
    }
    private void TryUpdateFallDamage()
    {
        if (_maxFallVelocity < _rigidBody.velocity.y)
        {
            _maxFallVelocity = _rigidBody.velocity.y;
        }
    }
}
