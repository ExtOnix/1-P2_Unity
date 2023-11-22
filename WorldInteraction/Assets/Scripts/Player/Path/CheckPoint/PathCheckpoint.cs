using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCheckpoint : MonoBehaviour
{
    [SerializeField] Vector3 point = Vector3.zero;
    public Vector3 Point 
    {
        get => point;
        private set 
        {
            point = value;
        }
    }

    private void Awake()
    {
        Point = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

}
