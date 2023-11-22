using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="Path Asset")]
public class PathScript : ScriptableObject
{
    [SerializeField] List<PathCheckpoint> checkpointList = new();
    public List<PathCheckpoint>  CheckpointList => checkpointList;
    
}
