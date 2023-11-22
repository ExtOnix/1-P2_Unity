using UnityEngine;

[CreateAssetMenu(fileName = "Camera Settings")]
public class CameraSettingsFollow : CameraSettings
{
    [SerializeField, Header("Camera Settings")]
    MovementType movementType = MovementType.Lerp;
    [SerializeField] OffsetType offsetType = OffsetType.Local;
    [SerializeField, Range(-20, 20)] float offsetX = 0;
    [SerializeField, Range(-20, 20)] float offsetY = 0;
    [SerializeField, Range(-20, 20)] float offsetZ = 0;

    [SerializeField, Range(0, 10)] float cameraSpeed = 0;

    public float OffsetX => offsetX;
    public float OffsetY => offsetY;
    public float OffsetZ => offsetZ;
    public float CameraSpeed => cameraSpeed;

    public MovementType MovementType => movementType;
    public OffsetType OffsetType => offsetType;
}
