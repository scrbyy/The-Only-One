using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    public event Action PlayerJumpedEvent;

    [SerializeField] private List<float> _jumpForce;
    [SerializeField] private int _currentJump = 0;

    [SerializeField] private PlayerGroundCheck _playerGroundCheck;
    private Rigidbody _rigidBody;

    private void OnEnable()
    {
        _playerGroundCheck.PlayerFall += ResetJumpCounter;
    }
    private void OnDisable()
    {
        _playerGroundCheck.PlayerFall -= ResetJumpCounter;
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentJump < _jumpForce.Count)
        {
            _rigidBody.AddForce(_jumpForce[_currentJump] * Vector3.up, ForceMode.VelocityChange);
            _currentJump++;
            PlayerJumpedEvent?.Invoke();
        } 
    }

    private void ResetJumpCounter()
    {
        _currentJump = 0;
    }
}
