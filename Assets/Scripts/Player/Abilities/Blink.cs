using UnityEngine;

public class Blink : ActiveAbility
{
    [field: SerializeField] protected override string showingName { get; set; }
    [field: SerializeField] protected override int manaUsage { get; set; }

    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _cameraOrigin;
    private RaycastHit _hit;

    public override void UseAbility()
    {
        if (Input.GetMouseButton(0))
        {
            _target.gameObject.SetActive(true);
            if (Physics.Raycast(this.transform.position, _cameraOrigin.forward, out _hit, _distance))
            {
                _target.position = _hit.point;
                CheckUnderFloor();
            }
            else
            {
                _target.position = _cameraOrigin.position + _cameraOrigin.forward * _distance;
                Debug.DrawLine(transform.TransformPoint(_cameraOrigin.forward), transform.TransformPoint(_cameraOrigin.forward * _distance));
                CheckUnderFloor();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _target.gameObject.SetActive(false);
            TeleportPlayer();
        }
    }
    private void CheckUnderFloor()
    {
        if(_target.position.y < 0)
        {
            _target.position = new Vector3(_target.position.x, 0, _target.position.z);
        }
    }
    private void TeleportPlayer()
    {
        if (_target.position.y == 0)
        {
            this.transform.position = new Vector3(_target.position.x, _target.position.y + transform.localScale.y, _target.position.z);
        }

        {
            this.transform.position = _target.position;
        }
    }
}
