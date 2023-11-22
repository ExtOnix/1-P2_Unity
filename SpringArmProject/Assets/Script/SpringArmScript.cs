using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpringArmScript : MonoBehaviour
{
    [SerializeField,Range(1,10),Header("Spring Arm Settings")] float length = 5;
    [SerializeField, Range(0, 360)] float angle = 0;
    [SerializeField,Range(0,10)] float height = 2;
    [SerializeField, Header("Camera")] AttachedCamera attachedCamera = null;
    [SerializeField] LayerMask hitLayer;
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!attachedCamera)
            return;
        DetectObject();
        UpdateCameraPosition();
    }
    void Init()
    {
        if (!attachedCamera)
            return;
        attachedCamera.SetTarget(transform);




    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, attachedCamera.transform.position);
        Gizmos.color = Color.red;
        Ray _r = new Ray(transform.position, transform.forward);
        Gizmos.DrawRay(_r.origin, _r.direction * length);
    }

    private void UpdateCameraPosition()
    {
        float _rad = angle * Mathf.Deg2Rad;
        attachedCamera.transform.position = Vector3.MoveTowards(attachedCamera.transform.position, transform.position + new Vector3(Mathf.Cos(_rad) * length,height , Mathf.Sin(_rad) * length),Time.deltaTime * 10);
    }

    void DetectObject()
    {
        bool _hitFwd = Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit _resultFwd, length, hitLayer);

        if (_hitFwd)
        {
            attachedCamera.transform.position = new Vector3(_resultFwd.transform.position.x, attachedCamera.transform.position.y, attachedCamera.transform.position.z);
        }
    }
}
