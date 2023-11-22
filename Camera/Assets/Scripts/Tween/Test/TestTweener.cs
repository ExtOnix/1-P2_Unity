using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTweener : MonoBehaviour
{
    Vector3 origin;
    void Start()
    {
        origin = transform.position;
        TweenLibrary.StartMoveTo(this, origin, Vector3.zero, TweenFunctions.Easing.easeInSine, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
