using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    Dictionary<string, CameraManaged> allCameras = new();

    public void AddCamera(CameraManaged _camera)
    {
        string _lowerID = _camera.CameraID.ToLower();
        if (allCameras.ContainsKey(_lowerID))
            return;
        allCameras.Add(_lowerID, _camera);
        _camera.name += "[MANAGED]";
    }
    public void RemoveCamera(CameraManaged _camera)
    {
        string _lowerID = _camera.CameraID.ToLower();
        if (!allCameras.ContainsKey(_lowerID))
            return;
        allCameras.Remove(_lowerID);

    }

    public void EnableCamera(CameraManaged _camera)
    {
        _camera.Enable();
    }

    public void DisableCamera(CameraManaged _camera)
    {
        _camera.Disable();
    }

    public void CreateCamera<T>(T _prefab,string _id, Transform _target) where T : CameraBehaviour
    {
        T _camera = Instantiate(_prefab);
        _camera.SetTarget(_target);
        _camera.GetComponent<CameraManaged>().RegisterCamera(_id);
    }





}
