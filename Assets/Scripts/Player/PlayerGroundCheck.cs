using System;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class PlayerGroundCheck : MonoBehaviour
{
    public event Action PlayerFall;

    [SerializeField] private PlayerJump _playerJump;
    [SerializeField] private bool isGrounded = true;

    private void OnEnable()
    {
        _playerJump.PlayerJumpedEvent += PlayerJump;
    }
    private void OnDisable()
    {
        _playerJump.PlayerJumpedEvent -= PlayerJump;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isGrounded == false)
        {
            PlayerFall?.Invoke();
            isGrounded = true;
        }
    }
    private void PlayerJump()
    {
        isGrounded = false;
    }
}
