using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : TriggerScript
{
    [SerializeField] CameraManaged cameraOn = null;
    [SerializeField] CameraManaged cameraOff = null;
    protected void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        PlayerScript _t = other.GetComponent<PlayerScript>();
        if (!_t)
            return;
        CameraManager.Instance?.EnableCamera(cameraOn);
        CameraManager.Instance?.DisableCamera(cameraOff);
        _t.CheckpointIndex++;


    }
}
