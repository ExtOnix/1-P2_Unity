using UnityEngine;

public class FirstScript : MonoBehaviour
{
    [SerializeField] float value = 2;
    public float Value => value;

    void Awake()
    {
        //Debug.Log("Awake");
    }
    void Start()
    {
        //Debug.Log("Start");
    }
    void Update()
    {
        //Debug.Log("Update");
    }
    void FixedUpdate()
    {
        //Debug.Log("Fixed Update");
    }
    private void LateUpdate()
    {
        //Debug.Log("Late Update");
    }
    private void OnDestroy()
    {
        //Debug.Log("Kill");
    }
}
