using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswersButton : MonoBehaviour
{
    [SerializeField] Button answerButton = null;
    [SerializeField] TMP_Text answerText = null;

    public bool IsValid => answerButton && answerText;

    public void Init(string _label, Action _todo)
    {
        if (!IsValid)
            throw new NullReferenceException("Answer Button element is null");
        answerText.text = _label;
        answerButton.onClick.AddListener(() => _todo?.Invoke());
    }
}
