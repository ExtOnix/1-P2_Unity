using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTester : MonoBehaviour
{
    [SerializeField] CameraFollow cameraFollow = null;
    WaitForSeconds wait = new(5);
   IEnumerator Start()
    {
        CameraManager.Instance.CreateCamera(cameraFollow,"Toto", transform);
        CameraManager.Instance.CreateCameraOrbit("orbit", transform);
        //CameraManager.Instance.EnableCamera("player");
        yield return wait;
        //CameraManager.Instance.DisableCamera("player");
    }
}
