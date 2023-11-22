using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerScript : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(5, 5, 1));//triggerZone.bounds.size
    }
}
