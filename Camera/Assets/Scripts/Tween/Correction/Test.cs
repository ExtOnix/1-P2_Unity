using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 origin;
    void Start()
    {
        origin = transform.position;
        Tweener.MoveToWithCallback(this, origin, Vector3.zero, TweenEase.EaseOutBounce, 5,
            () => Tweener.MoveTo(this, Vector3.zero,origin,TweenEase.EaseInBounce,5));
        this.MoveTo(TweenEase.EaseInBounce, Vector3.zero, 5);
    }

}
