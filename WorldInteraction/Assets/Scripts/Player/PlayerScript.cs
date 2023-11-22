using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] PathScript path = null;
    [SerializeField] int checkpointIndex = 0;
    public int CheckpointIndex
    {
        get => checkpointIndex;
        set => checkpointIndex = value;
    }

    private void Update()
    {
        UpdatePlayerPosition(transform);
    }
    public void UpdatePlayerPosition(Transform _t)
    {
        if (CheckpointIndex == path.CheckpointList.Count)
            return;
        _t.position = Vector3.MoveTowards(_t.position, path.CheckpointList[checkpointIndex].transform.position, Time.deltaTime);
    }
}
