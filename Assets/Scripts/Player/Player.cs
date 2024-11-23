using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action PlayerDieEvent;
    public static Action<float> PlayerTookDamageEvent;

    [SerializeField] private float _health;
    [SerializeField] private float _mana;

    public void TakeDamage(float value)
    {
        if(_health - value < 0)
        {
            PlayerDieEvent?.Invoke();   
        }
        else
        {
            _health -= value;
            PlayerTookDamageEvent?.Invoke(_health);
        }
    }
}
