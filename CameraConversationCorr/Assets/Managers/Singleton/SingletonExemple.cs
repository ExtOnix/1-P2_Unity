using UnityEngine;

public class SingletonExemple : Singleton<SingletonExemple>
{
    public void SayHello() => Debug.Log("hello");
}
