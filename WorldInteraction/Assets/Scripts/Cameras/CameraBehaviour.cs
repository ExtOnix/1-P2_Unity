using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBehaviour : MonoBehaviour
{
    [SerializeField] protected Transform target = null;
    [SerializeField] protected CameraSettings cameraSettings = null;
    public Transform Target => target;

    #region Debug
    [SerializeField, Header("Debug")] protected bool useDebug = true;
    [SerializeField] protected Color validDebugColor = Color.green, noValidDebugColor = Color.red;
    #endregion

    #region Properties
    public Vector3 CurrentPosition => transform.position;
    public virtual Vector3 TargetPosition
    {
        get
        {
            if (!target)
                throw new NullReferenceException();
            return target.position;
        }
        set { }
    }
    #endregion
    public void SetTarget(Transform _target) => target = _target;

    protected void LateUpdate()
    {
        UpdateBehaviour();
    }
    protected void OnDrawGizmos()
    {
        DrawDebug();
    }

    void DrawDebug()
    {

    }

    abstract protected void UpdateBehaviour();

    protected T CastSettings<T>() where T : CameraSettings
    {
        return (T)cameraSettings;
    }






}
