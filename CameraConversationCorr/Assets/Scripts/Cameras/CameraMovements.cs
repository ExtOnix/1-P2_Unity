using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public enum MovementType
{
    Lerp,
    ConstantLerp
}
public enum OffsetType
{
    World,
    Local
}

[RequireComponent(typeof(CameraManaged))]
public abstract class CameraMovements : MonoBehaviour
{
    #region Settings
    [SerializeField] protected Transform target = null;
    [SerializeField] protected CameraSettings cameraSettings = null;
    #endregion

    #region Debug
    [SerializeField, Header("Debug")] protected bool useDebug = true;
    [SerializeField] protected Color validDebugColor = Color.green, noValidDebugColor = Color.red;
    #endregion

    #region Properties
    public bool IsValid => target;
    public Vector3 CurrentPosition => transform.position;
    public virtual Vector3 TargetPosition
    {
        get
        {
            if (!target)
                throw new CameraTargetNullReference();
            return target.position;
        }
        set { }
    }
    public virtual Vector3 FinalPosition => target ? target.position + Offset : CurrentPosition;
    public virtual Vector3 Offset
    {
        get;

    }

    #endregion
    private void LateUpdate()
    {
        UpdateCameraPosition();
        UpdateLookAtCamera();
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    protected virtual void UpdateCameraPosition()
    {
        
    }

    protected virtual void UpdateLookAtCamera()
    {
        Vector3 _fwd = (TargetPosition - transform.position).normalized;
        Vector3 _right = Vector3.Cross(Vector3.up, _fwd).normalized;
        Vector3 _up = Vector3.Cross(_fwd, _right);
        Matrix4x4 _matrix = new Matrix4x4(_right, _up, _fwd, new Vector4(0,0,0,1));
       transform.rotation = Quaternion.RotateTowards(transform.rotation,_matrix.rotation,Time.deltaTime * 100);
    }
    private void OnDrawGizmos()
    {
        DrawDebugMovement();
    }
    
    protected virtual void DrawDebugMovement()
    {
        
    }

    protected Vector3 GetLocalOffset(float _x, float _y, float _z)
    {
        return (target.right * _x) + (target.up * _y) + (target.forward * _z);
    }

    protected T CastSettings<T>() where T : CameraSettings
    {
        return (T)cameraSettings;
    }

}
