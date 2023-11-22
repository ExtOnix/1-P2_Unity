using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PNJ Camera Settings")]
public class PNJCameraSettingsBasic : PNJCameraSettings
{
    [SerializeField, Range(0, 1)] float targetPivot = .5f;
    [SerializeField, Range(0, 360)] float angle = 45;
    [SerializeField, Range(0, 100)] float height = 2;
    [SerializeField] PNJCameraFollow cameraObject = null;

    public float TargetPivot { get { return targetPivot; } }
    public float Angle { get { return angle; } }
    public float Height { get { return height; } }
    public PNJCameraFollow CameraObject { get { return cameraObject; } }
}
