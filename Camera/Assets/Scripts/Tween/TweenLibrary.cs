using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class TweenLibrary
{
    public static event Action<float> OnMove = null;
    public static AnimationCurve Curve { get; } = new AnimationCurve();

    public static void StartMoveTo(MonoBehaviour _obj ,Vector3 _from, Vector3 _to, TweenFunctions.Easing _easing, float _time)
    {
        OnMove += (_time) => _obj.StartCoroutine(UpdateObjectPosition(_obj, _from, _to,_easing, _time));
        OnMove?.Invoke(0f);
    }

    public static IEnumerator UpdateObjectPosition(MonoBehaviour _obj, Vector3 _from, Vector3 _to, TweenFunctions.Easing _easing,  float _time)
    {
        Debug.Log("test");
        float _currentTime = 0;
        _obj.GameObject().transform.position = Vector3.Lerp(_from, _to, Curve.Evaluate(TweenFunctions.ChooseFunction(_easing,_currentTime/_time)));
        _currentTime += Time.deltaTime;
        if (_currentTime < _time)
        {
            yield return new WaitForEndOfFrame();
            OnMove?.Invoke(_currentTime);
        }
    }
}
