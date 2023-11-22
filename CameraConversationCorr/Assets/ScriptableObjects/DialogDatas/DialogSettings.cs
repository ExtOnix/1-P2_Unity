using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog Settings")]
public class DialogSettings : ScriptableObject
{

    public event Action<Dialog> OnNext = null;
    [SerializeField] Dialog[] allDialogs = null;
    public Dialog this[int i] => allDialogs[i];

    public Dialog CurrentDialog => allDialogs[DialogProgress];
    public int DialogProgress { get; private set; }
    public int Length => allDialogs.Length;

    public void StartDialog()
    {
        DialogProgress = 0;
        OnNext?.Invoke(CurrentDialog);
    }

    public void SetNextDialog()
    {
        DialogProgress++;
        DialogProgress %= allDialogs.Length;
        OnNext?.Invoke(CurrentDialog);
    }
}
