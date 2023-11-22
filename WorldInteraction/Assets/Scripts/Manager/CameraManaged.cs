using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManaged : MonoBehaviour
{
    #region Properties
    [SerializeField] string cameraID = "Camera";
    [SerializeField] Camera cameraView = null;
    [SerializeField] CameraBehaviour cameraBehaviour = null;

    public string CameraID => cameraID;
    #endregion

    private void Start()
    {
        Init();
    }

    void Init()
    {
        cameraBehaviour = GetComponent<CameraBehaviour>();
        cameraView = GetComponent<Camera>();
        CameraManager.Instance?.AddCamera(this);
    }

    private void OnDestroy()
    {
        CameraManager.Instance?.RemoveCamera(this);
    }

    public void Enable()
    {
        cameraBehaviour.enabled = true;
        cameraView.enabled = true;
    }

    public void Disable()
    {
        cameraBehaviour.enabled = false;
        cameraView.enabled = false;

    }

    public void RegisterCamera(string _id)
    {
        cameraID = _id;
        CameraManager.Instance.AddCamera(this);
    }

}
