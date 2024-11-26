using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action PlayerDieEvent;
    public static Action<float> PlayerTookDamageEvent;

    [SerializeField] private float _health;
    [SerializeField] private float _mana;

    public void TakeDamage(float damage)
    {
        if(damage < 0)
        {
            throw new System.Exception("Damage < 0!");
        }
        else
        {
            _health -= damage;
            PlayerTookDamageEvent?.Invoke(_health);
        }
    }
}
