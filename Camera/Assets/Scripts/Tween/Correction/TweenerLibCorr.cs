using UnityEngine;

public enum TweenEase
{
    EaseInSine,
    EaseOutQuint,
    EaseInBounce,
    EaseOutBounce
}
public class TweenerLibCorr
{
    public static float GetTweenAlpha(TweenEase _ease,float _progress)
    {
        switch (_ease)
        {
            case TweenEase.EaseInBounce:
                return EaseInBounce(_progress);
            case TweenEase.EaseOutBounce:
                return EaseOutBounce(_progress);
            case TweenEase.EaseInSine:
                return EaseInSine(_progress);
            case TweenEase.EaseOutQuint:
                return EaseOutQuint(_progress);
            default:
                return 0;
        }   
    }

    static float EaseInSine(float _progress) => 1 - Mathf.Cos((_progress * Mathf.PI) / 2);
    static float EaseOutQuint(float _progress)=> 1 - Mathf.Pow(1-_progress,5);
    static float EaseInBounce(float _progress) => 1 - EaseOutBounce(1-_progress);
    static float EaseOutBounce(float _progress)
    {
        float _n1 = 7.5625f,
                _d1 = 2.75f;
        if (_progress < 1 / _d1)
            return _n1 * _progress * _progress;
        else if (_progress < 2 / _d1)
            return _n1 * (_progress -= 1.5f / _d1) * _progress + .75f;
        else if (_progress < 2.5f / _d1)
            return _n1 * (_progress -= 2.25f / _d1) * _progress + 0.9375f;
        else
            return _n1 * (_progress -= 2.625f / _d1) * _progress + 0.984375f;
    }
}
