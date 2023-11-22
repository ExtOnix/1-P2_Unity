using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    Dictionary<string, CameraManaged> allCameras = new();
    [SerializeField] CameraFollow cameraFollowType = null;
    [SerializeField] OrbitalCamera cameraOrbitType = null;

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

    public void DisableCamera(string _camera)
    {
        allCameras[_camera.ToLower()].Disable();
    }

    public void EnableCamera(string _camera)
    {
        allCameras[_camera.ToLower()].Enable();
    }

    public void CreateCamera<T>(T _prefab, string _id, Transform _target)  where T : CameraMovements
    {
        T _instance = Instantiate(_prefab);
        _instance.SetTarget(_target);
        _instance.GetComponent<CameraManaged>().RegisterCamera(_id);
    }

    public void CreateCameraOrbit(string _id, Transform _target)
    {
        OrbitalCamera _instance = Instantiate(cameraOrbitType);
        _instance.SetTarget(_target);
        _instance.GetComponent<CameraManaged>().RegisterCamera(_id);
    }

    public void CreateCameraFollow(string _id, Transform _target)
    {
        CameraFollow _instance = Instantiate(cameraFollowType);
        _instance.SetTarget(_target);
        _instance.GetComponent<CameraManaged>().RegisterCamera(_id);
    }
}
