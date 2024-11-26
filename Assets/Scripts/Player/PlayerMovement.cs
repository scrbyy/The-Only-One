using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static Action PlayerRunEvent;
    public static Action PlayerWalkEvent;

    [SerializeField] private float _speed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private Vector3 _moveDirection;
    private Rigidbody _rigidBody;

    private void OnEnable()
    {
        PlayerRunEvent += SetRunSpeed;
        PlayerWalkEvent += SetWalkSpeed;
    }
    private void OnDisable()
    {
        PlayerRunEvent -= SetRunSpeed;
        PlayerWalkEvent -= SetWalkSpeed;
    }
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * _speed;
        float vInput = Input.GetAxis("Vertical") * _speed;

        _moveDirection = new Vector3(hInput, _rigidBody.velocity.y, vInput);
        _moveDirection = transform.TransformDirection(_moveDirection);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerRunEvent?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerWalkEvent?.Invoke();
        }
    }
    private void FixedUpdate()
    {
        _rigidBody.velocity = _moveDirection;
    }
    private void SetRunSpeed()
    {
        _speed = _runSpeed;
    }
    private void SetWalkSpeed()
    {
        _speed = _walkSpeed;
    }
}
