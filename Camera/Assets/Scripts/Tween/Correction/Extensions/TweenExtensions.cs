using UnityEngine;

public static class TweenExtensions
{
   public static void MoveTo(this MonoBehaviour _ob,TweenEase _ease, Vector3 _target, float _duration)
    {
        Vector3 _origin = _ob.transform.position;
        Tweener.MoveTo(_ob,_origin, _target,_ease, _duration);
    }

    public static T ToSpawn<T>(this GameObject _ob, T _object) where T : Component
    {
        return UnityEngine.Object.Instantiate(_object);
    }

    public static int ToInt(this string _string)
    {
       int.TryParse( _string, out int _result);
        return _result;
    }
}
