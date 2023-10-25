using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    [SerializeField] Button answerButton = null;
    [SerializeField] TMP_Text answerText = null;

    public bool IsValid => answerButton && answerText;

    public void Init(string _label, Action _todo)
    {
        if (!IsValid)
            return;
        answerText.text = _label;
        answerButton.onClick.AddListener(() => _todo?.Invoke());
    }
}
