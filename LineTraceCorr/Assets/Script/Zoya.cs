using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class Zoya : MonoBehaviour
{
    [SerializeField] int bounces = 5;
    Vector3[] points;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ZoyaBounce();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < points?.Length; i++)
        {
            if (i < points.Length - 1)
                Gizmos.DrawLine(points[i], points[i + 1]);
            Gizmos.DrawSphere(points[i], .5f);
        }
    }
    void ZoyaBounce()
    {
        points = new Vector3[bounces];
        RaycastHit _result;
        Ray _r = new Ray(transform.position, transform.forward);
        for (int i = 0; i < bounces; i++)
        {
            points[i] = _r.origin;
            Physics.Raycast(_r.origin, _r.direction, out _result, 100);
            //Debug.DrawRay(_r.origin, _r.direction * 100,Color.red);
            _r = new Ray(_result.point, Vector3.Reflect(_r.direction, _result.normal));
        }
    }
    

    Vector3 Reflect(Vector3 _dir, Vector3 _normal)
    {
        return _dir - 2 * Vector3.Dot(_dir,_normal) * _normal;
    }
}
