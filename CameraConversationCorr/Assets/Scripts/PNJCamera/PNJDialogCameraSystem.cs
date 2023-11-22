using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJDialogCameraSystem : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] DialogSettings dialogSettings = null;
    [SerializeField] PNJCameraSettings settings = null;
    PNJCameraFollow cameraActive = null;
    Transform targetActive = null;

    #region Properties
    public Transform Target => target;
    public float DistanceToTarget => Vector3.Distance(CurrentPNJLocation, CurrentTargetPosition); //magnitude
    public float Radius => DistanceToTarget / 2;

    public Vector3 CameraPosition => GetCameraPosition(CastSettings<PNJCameraSettingsBasic>(settings).Angle, Radius);
    public Vector3 CameraPositionWhitoutHeight => GetCameraPosition(CastSettings<PNJCameraSettingsBasic>(settings).Angle, Radius) - Height;

    public Vector3 CurrentPNJLocation => transform.position;
    public Vector3 Height => Vector3.up * CastSettings<PNJCameraSettingsBasic>(settings).Height;
    public Vector3 CurrentTargetPosition
    {
        get
        {
            if (!target)
                throw new System.NullReferenceException("NullRef : target is  missing");
            return target.position;
        }
    }
    public Vector3 TargetPivot => Vector3.Lerp(CurrentPNJLocation, CurrentTargetPosition, CastSettings<PNJCameraSettingsBasic>(settings).TargetPivot);

    #endregion

    public Vector3 LookAt { get; private set; }

    public void InitCameraDialog()
    {
        cameraActive = Instantiate(CastSettings<PNJCameraSettingsBasic>(settings).CameraObject,CameraPosition,Quaternion.identity);
        cameraActive.transform.forward = CurrentPNJLocation - cameraActive.transform.position;
        targetActive = Instantiate(target);
    }
    void UpdateCameraLocation()
    {
        if (!cameraActive)
            return;
        cameraActive.SetDestination(CameraPosition);
        if(!dialogSettings.CurrentDialog.IsPNJ)
            cameraActive.SetLookAt(transform.position);
        else
            cameraActive.SetLookAt(target.position);
    }
    private void Update()
    {
        UpdateCameraLocation();
    }

    public Vector3 GetCameraPosition(float _angle = 45, float _radius = 10)
    {
        float _rad = _angle * Mathf.Deg2Rad;
        return TargetPivot + new Vector3(Mathf.Cos(_rad) * _radius, CastSettings<PNJCameraSettingsBasic>(settings).Height, Mathf.Sin(_rad) * _radius);
    }
    public void SetTarget(Transform _target) => target = _target;
    //public void SetLookAt(bool _isPNJ) => LookAt = _isPNJ ? CurrentPNJLocation : CurrentTargetPosition;

    T CastSettings<T>(PNJCameraSettings _settings) where T : PNJCameraSettings { return (T)_settings; }

    private void OnDrawGizmos()
    {
        Gizmos.color = target ? Color.green : Color.red;
        Gizmos.DrawSphere(target ? CurrentTargetPosition + Vector3.up * 2 : Vector3.zero, .2f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(CurrentTargetPosition, CurrentPNJLocation);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(TargetPivot, .2f);
        GizmosUtils.DrawCircle(TargetPivot, Radius,Color.red,30);
        Gizmos.DrawSphere(CameraPosition, .2f);
        Gizmos.DrawLine(CameraPositionWhitoutHeight, TargetPivot);
        Gizmos.DrawLine(CameraPosition, TargetPivot);
        Gizmos.DrawLine(CameraPosition, CameraPositionWhitoutHeight);
    }
}
