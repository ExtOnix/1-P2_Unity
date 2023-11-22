using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenFunctions
{
    public enum Easing
    {
        easeInSine
    }

    public static float ChooseFunction(Easing _easing, float _t)
    {
        switch (_easing)
        {
            case Easing.easeInSine:
                return 1 - Mathf.Cos((_t * Mathf.PI) / 2);
            default:
                return 0;
        }
    }
}
