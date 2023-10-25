using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] AnswerButtons answers = null;
    [SerializeField] Transform answersContent = null;

    public bool IsValid => answers && answersContent;

    private void Awake()
    {
        NetworkAPI.OnQuestion += GenerateQuestion;
    }

    void GenerateQuestion(Questions[] _question)
    {
        ClearAnswers();
        for (int i = 0; IsValid && i < 10; i++)
        {
            int _index = i;
            AnswerButtons _button = Instantiate(answers, answersContent);
            Debug.Log(_question[_index].Answers);
            _button.Init($"{_question[_index].Answers}", () => Debug.Log($"Ouais"));
        }
    }

    void ClearAnswers()
    {
       
    }

}
