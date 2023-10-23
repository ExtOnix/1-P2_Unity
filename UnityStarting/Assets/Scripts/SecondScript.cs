using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScript : MonoBehaviour
{
    [SerializeField] FirstScript firstScript = null;
    [SerializeField] FirstScript instance = null;

    private void Start() => Init();
    void Init()
    {
        Debug.Log($"FROM {name} TO {firstScript?.name} => COUCOU => {firstScript?.Value}");
        instance = gameObject.AddComponent<FirstScript>();
    }
}
