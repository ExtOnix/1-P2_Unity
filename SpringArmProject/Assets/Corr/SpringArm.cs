using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    Transform cameraTransform = null;
    [SerializeField, Range(1, 10)] float armLength = 5;

    public Vector3 FinalPoint => transform.position + transform.forward * -armLength;
    void Start() => FindCamera();
    private void LateUpdate()
    {
        UpdateCameraPosition(GetCameraAlpha());
    }

    float GetCameraAlpha()
    {
        bool _result = Physics.Raycast(new Ray(transform.position,transform.forward * -armLength),out RaycastHit _hitInfo, armLength);
        return _result ? (_hitInfo.distance / armLength) : 1;
    }

    void FindCamera()
    {
        if (transform.childCount == 0)
            return;
        Camera _cam = transform.GetChild(0).GetComponent<Camera>();
        if (!_cam)
            cameraTransform = _cam.transform;
    }

    void UpdateCameraPosition(float _alpha = 1)
    {
        if (!cameraTransform)
            return;
        cameraTransform.transform.position = Vector3.Lerp(transform.position, FinalPoint, _alpha);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = cameraTransform ?Color.red : Color.gray;
        Gizmos.DrawRay(transform.position, transform.forward * -armLength);
    }
}
