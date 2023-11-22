using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Tweener
{
   public static void MoveTo(MonoBehaviour _obj, Vector3 _origin, Vector3 _target, TweenEase _ease, float _duration = 1)
   {
        _obj.StartCoroutine(MoveToCoroutine(_obj.transform,_origin,_target,_ease,_duration,null));
   }

    public static void MoveToWithCallback(MonoBehaviour _obj, Vector3 _origin, Vector3 _target, TweenEase _ease, float _duration = 1, Action _callback = null)
    {
        _obj.StartCoroutine(MoveToCoroutine(_obj.transform, _origin, _target, _ease, _duration, _callback));

    }

    static IEnumerator MoveToCoroutine(Transform _tr, Vector3 _origin, Vector3 _target, TweenEase _ease, float _duration = 1, Action _callback = null)
    {
        float _time = 0;
        float _progress = 0;
        while(_time <= _duration)
        {
            _time += Time.deltaTime;
            _progress = _time / _duration;
            _tr.position = Vector3.Lerp(_origin,_target,TweenerLibCorr.GetTweenAlpha(_ease, _progress));
            yield return null;
        }
        _callback?.Invoke();
    }
}
