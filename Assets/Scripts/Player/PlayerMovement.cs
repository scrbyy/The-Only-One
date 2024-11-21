using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static Action PlayerRunEvent;
    public static Action PlayerWalkEvent;

    [SerializeField] private float _accurancy;
    [SerializeField] private float _maxWalkSpeed;
    [SerializeField] private float _runSpeed;

    private Vector3 _moveDirection;
    private Rigidbody _rigidBody;
    private float _maxSpeed;

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
        _maxSpeed = _maxWalkSpeed;
        _rigidBody = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * _accurancy;
        float vInput = Input.GetAxis("Vertical") * _accurancy;
        _moveDirection = new Vector3(hInput, Physics.gravity.y, vInput);
        _moveDirection = transform.TransformDirection(_moveDirection);

        if(_rigidBody.velocity.x < _maxSpeed && _rigidBody.velocity.z < _maxSpeed)
        {
            _rigidBody.AddForce(_moveDirection, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerRunEvent?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerWalkEvent?.Invoke();
        }
    }
    private void SetRunSpeed()
    {
        _maxSpeed = _runSpeed;
    }
    private void SetWalkSpeed()
    {
        _maxSpeed = _maxWalkSpeed;
    }
}
