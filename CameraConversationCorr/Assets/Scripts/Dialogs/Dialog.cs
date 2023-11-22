using UnityEngine;
using System;
using UnityEngine.UIElements;

[Serializable]
public class Dialog 
{
    [SerializeField] string quote = "Exemple...";
    [SerializeField] Choice[] choices = null;
    [SerializeField] bool isPNJ = false;
    public bool IsPNJ => isPNJ;
    public Choice this[int _index] => choices[_index];
    public int Length => choices.Length;
    public string Quote => quote;
}
