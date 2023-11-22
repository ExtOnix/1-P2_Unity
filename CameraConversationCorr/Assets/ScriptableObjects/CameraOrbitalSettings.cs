using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Camera Orbital Settings")]
public class CameraOrbitalSettings : CameraSettings
{
    [SerializeField, Header("Orbital Settings"), Range(.1f, 10)]
    float radius = 2;
    [SerializeField]
    AnimationCurve expression = new AnimationCurve(new Keyframe[]
    {
        new Keyframe(0,0),
        new Keyframe(1,1),
    });

    public float Radius => radius;
    public AnimationCurve Expression => expression;
}
