using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] FirstScript toSpawn = null;
    FirstScript clone = null;

    private void Start() =>  Spawn();
    void Spawn()
    {
        if (!toSpawn)
            return;
        clone = Instantiate(toSpawn,transform.position + transform.up *2, Quaternion.Euler(new Vector3(45,0,0)));
        Debug.Log(clone?.Value);
    }

}
