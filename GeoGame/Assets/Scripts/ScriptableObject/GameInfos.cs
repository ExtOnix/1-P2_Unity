using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameInfos : ScriptableObject
{
    [SerializeField]
    float bestScore = 0;
    [SerializeField]
    List<int> allIDs = new List<int>();

    public float BestScore
    {
        get => bestScore;
        set
        {
            bestScore = value;
        }
    }

    public List<int> AllIDs
    {
        get => allIDs;
        set
        {
            allIDs = value;
        }
    }
}
