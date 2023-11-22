using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrbitalCamera : CameraMovements
{
    public override Vector3 FinalPosition => RotationPoint() + TargetPosition ;
    float angle = 0;
    //[SerializeField, Range(1, 10)]
    //float duration = 1;

    private void Start()
    {
        
    }

    protected override void UpdateCameraPosition()
    {
        transform.position = FinalPosition;
    }
    protected override void DrawDebugMovement()
    {
        Gizmos.DrawWireSphere(TargetPosition, CastSettings<CameraOrbitalSettings>().Radius);
    }

    Vector3 RotationPoint()
    {
        angle = ComputeAngle();
        float _x = Mathf.Cos(angle* Mathf.Deg2Rad) * CastSettings<CameraOrbitalSettings>().Radius,
            _z = Mathf.Sin(angle* Mathf.Deg2Rad) * CastSettings<CameraOrbitalSettings>().Radius;
        return new Vector3(_x,0,_z);
    }

    float ComputeAngle()
    {
        return CastSettings<CameraOrbitalSettings>().Expression.Evaluate(Time.time) * 360;
        //angle += Mathf.MoveTowards(angle,1,Time.deltaTime);
        //angle %= 360;
        //return angle;

    }
    
}
