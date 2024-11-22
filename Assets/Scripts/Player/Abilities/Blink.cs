using UnityEngine;

public class Blink : ActiveAbility
{
    [field: SerializeField] protected override string _showingName { get; set; }
    [field: SerializeField] protected override int _manaUsage { get; set; }

    [SerializeField] private Transform _blinkSphere;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _cameraOrigin;
    private RaycastHit _hit;

    public override void UseAbility()
    {
        if (Input.GetMouseButton(0))
        {
            _blinkSphere.gameObject.SetActive(true);
            if (Physics.Raycast(this.transform.position, _cameraOrigin.forward, out _hit, _distance))
            {
                _blinkSphere.position = _hit.point;
            }
            else
            {
                _blinkSphere.position = _cameraOrigin.position + _cameraOrigin.forward * _distance;
                Debug.DrawLine(transform.TransformPoint(_cameraOrigin.forward), transform.TransformPoint(_cameraOrigin.forward * _distance));
                CheckUnderFloor();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _blinkSphere.gameObject.SetActive(false);
            TeleportPlayer();
        }
    }
    private void CheckUnderFloor()
    {
        if(_blinkSphere.position.y < 0)
        {
            _blinkSphere.position = new Vector3(_blinkSphere.position.x, 0, _blinkSphere.position.z);
        }
    }
    private void TeleportPlayer()
    {
        if (_blinkSphere.position.y == 0)
        {
            this.transform.position = new Vector3(_blinkSphere.position.x, _blinkSphere.position.y + transform.localScale.y, _blinkSphere.position.z);
        }

        {
            this.transform.position = _blinkSphere.position;
        }
    }
}
