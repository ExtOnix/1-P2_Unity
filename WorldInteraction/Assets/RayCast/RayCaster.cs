using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    Vector3 hitPoint;
    float pointRange = 100;
    [SerializeField] LayerMask hitLayer;

    private void Start()
    {
        Init();
        
    }

    void Init()
    {
        
    }
    private void Update()
    {
        DetectObject();
    }

    void DetectObject()
    {
        
        bool _hit = Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit _result,100,~hitLayer);
        if(_hit)
        {
            //T_get = _result.collider.GetComponent<T>()
            Debug.Log($"{pointRange = _result.distance} {_result.collider.name} {hitPoint = _result.point}");

        }
        else
        {
            hitPoint = transform.position;
            pointRange = 100;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray _r = new Ray(transform.position,transform.forward);
        Gizmos.DrawRay(_r.origin,_r.direction *pointRange);
        Gizmos.color= Color.magenta;
        Gizmos.DrawSphere(hitPoint, .2f);
    }
}
