using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]
public class PlayerFallDamage : MonoBehaviour
{
    [SerializeField] private PlayerGroundCheck _playerGroundCheck;
    [SerializeField] private float _damageDivider;
    [SerializeField] private float _minDamage;

    private Rigidbody _rigidBody;
    private Player _player;

    private float _maxFallDamage;

    private void OnEnable()
    {
        _playerGroundCheck.PlayerFall += GetFallDamage;
    }
    private void OnDisable()
    {
        _playerGroundCheck.PlayerFall -= GetFallDamage;
    }
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
    }
    private void Update()
    {
        if(_rigidBody.velocity.y < _maxFallDamage)
        {
            _maxFallDamage = _rigidBody.velocity.y;
        }
    }
    private void GetFallDamage()
    {
        float damage = Mathf.Pow(_maxFallDamage, 2) / _damageDivider;
        if (damage > _minDamage)
        {
            Debug.Log(damage);
            _player.TakeDamage(damage - _minDamage);
        }
    }
}
