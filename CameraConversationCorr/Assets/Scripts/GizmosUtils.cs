using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class GizmosUtils
{

    static public void DrawCircle(Vector3 _center, float _radius, Color _color, float _definition = 20)
    {
        Gizmos.color = _color;
        float _part = 360 / _definition;
        for (int i = 0; i < _definition + 1; i++)
        {
            float _a = (_part * i) * Mathf.Deg2Rad,
           _b = (_part * (i + 1)) * Mathf.Deg2Rad;
            Vector3 _from = new Vector3(Mathf.Cos(_a) * _radius, 0, Mathf.Sin(_a) * _radius),
                _to = new Vector3(Mathf.Cos(_b) * _radius, 0, Mathf.Sin(_b) * _radius);
            Gizmos.DrawLine(_from + _center,_to + _center);
        }
        Gizmos.color = Color.white;
    }
}
