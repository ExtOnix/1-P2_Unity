using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class AnswerButtons : MonoBehaviour
{
    #region f/p
    [SerializeField] Button answerButton = null;
    [SerializeField] TMP_Text answerText = null;

    public bool IsValid => answerButton && answerText;
    #endregion

    #region Methods
    public void Init(string _label, Action _todo)
    {
        if (!IsValid)
            return;
        answerText.text = _label;
        answerButton.onClick.AddListener(() => _todo?.Invoke());
    }
    #endregion

   
}
