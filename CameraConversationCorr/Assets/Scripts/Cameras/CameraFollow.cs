using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public enum CameraBehaviour
{
    Ease,
    ConstantLerp
}

public class CameraFollow : CameraMovements
{
    public override Vector3 Offset
    {
        get
        {
            CameraSettingsFollow _set = CastSettings<CameraSettingsFollow>();
            if (_set.OffsetType == OffsetType.Local)
                return GetLocalOffset(_set.OffsetX, _set.OffsetY, _set.OffsetZ);
            else
                return new Vector3(_set.OffsetX, _set.OffsetY, _set.OffsetZ);
        }
    }
    protected override void UpdateCameraPosition()
    {
        CameraSettingsFollow _set = CastSettings<CameraSettingsFollow>();
        if (_set.MovementType == MovementType.Lerp)
            transform.position = Vector3.Lerp(CurrentPosition, FinalPosition, Time.deltaTime * _set.CameraSpeed);
        else
            transform.position = Vector3.MoveTowards(CurrentPosition, FinalPosition, Time.deltaTime * _set.CameraSpeed);
    }

    protected override void DrawDebugMovement()
    {
        base.DrawDebugMovement();
        if (!useDebug) return;
        Gizmos.color = IsValid ? validDebugColor : noValidDebugColor;
        Gizmos.DrawWireCube(CurrentPosition, Vector3.one * .4f);
        if (!IsValid)
            return;
        Gizmos.DrawLine(CurrentPosition, FinalPosition);
        Vector3 _targetGizmo = FinalPosition + Vector3.up;
        Gizmos.DrawSphere(_targetGizmo, .1f);
        Gizmos.DrawLine(FinalPosition, _targetGizmo);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(CurrentPosition, TargetPosition);
        Gizmos.DrawLine(FinalPosition, TargetPosition);
        Gizmos.DrawCube(FinalPosition, Vector3.one * .1f);
        Gizmos.DrawWireSphere(TargetPosition, .7f);
    }

}
