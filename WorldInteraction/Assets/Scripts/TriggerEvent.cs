using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Test _t = other.GetComponent<Test>();
        if (!_t)
            return;
        Debug.Log("Enter " + other.name);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay " + other.name);
        
    }
    private void OnTriggerExit(Collider other) //COLLIDER
    {
        Debug.Log("Exit " + other.name);
        
    }
    private void OnCollisionEnter(Collision collision) //COLLISION
    {
        
    }
}
public class Test : MonoBehaviour
{

}
