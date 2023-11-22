using UnityEditor.Rendering;
using UnityEngine;

public class CamZoneCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] Camera view = null;
    [SerializeField,Range(1,100)] float speed = 10;
    [SerializeField] bool canLookAt = true;

    private void LateUpdate()
    {

            LookAtTarget();
    }
    
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void LookAtTarget()
    {
        if (!target || !canLookAt)
            return;
        else
        {
            Quaternion _fwd = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _fwd, Time.deltaTime * speed);
        }
    }

    public void EnableView(bool _status)
    {
        view.enabled = _status;
    }
}
