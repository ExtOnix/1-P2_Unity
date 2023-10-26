using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static event Action OnWon = null;

    [SerializeField] AnswerButtons answers = null;
    [SerializeField] Transform answersContent = null;
    [SerializeField] TMP_Text questionText = null;

    public bool IsValid => answers && answersContent;

    private void Awake()
    {
        NetworkAPI.OnQuizz += GenerateQuestion;
    }

    void GenerateQuestion(Quizz quizz)
    {
        ClearAnswers(answersContent);
        questionText.text = (quizz.Quizzes[0].Question);
        for (int i = 0; IsValid && i < 4; i++)
        {
            int _index = i;
            AnswerButtons _button = Instantiate(answers, answersContent);
            _button.Init($"{quizz.Quizzes[0].Answers[_index]}",() => Validate(quizz, _index));
        }
    }

    void ClearAnswers(Transform _tr)
    {
        for (int i = 0; i < _tr.childCount; i++)
        {
            Destroy(_tr.GetChild(i).gameObject);
        }
    }

    int GetIndex(int _index)
    {
        Debug.Log(_index);
        return 0;
    }

    void Validate(Quizz _quizz, int _index)
    {
        Questions _question = _quizz.Quizzes[0];
        if (_question.Answers[_index] == _question.Answer)
        {
            Debug.Log($"You Won");
            Questions.RandomDone = false;
            OnWon?.Invoke();
        }
        else
        {
            Debug.Log($"WRONG");
        }
    }


}
