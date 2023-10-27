using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static event Action OnWon = null;
    #region f/p
    [SerializeField] AnswerButtons answers = null;
    [SerializeField] Transform answersContent = null;
    [SerializeField] TMP_Text questionText = null;

    [SerializeField] Sprite goodSprite = null;
    [SerializeField] Sprite wrongSprite = null;

    [SerializeField] Button answersCallback = null;
    public bool IsValid => answers && answersContent;
    #endregion

    #region Unity
    private void Awake()
    {
        NetworkAPI.OnQuizz += GenerateQuestion;
    }
    #endregion

    #region Methods
    void GenerateQuestion(Quizz quizz)
    {
        ClearAnswers(answersContent);
        answersCallback.gameObject.SetActive(false);
        if (quizz.Quizzes.Length < 1)
        {
            questionText.text = "Il n'y a pas de questions disponibles dans cette difficulté";
            return;
        }
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
        answersCallback.GetComponentInChildren<TMP_Text>().text = string.Empty;
    }
    void Validate(Quizz _quizz, int _index)
    {
        Questions _question = _quizz.Quizzes[0];
        answersCallback.gameObject.SetActive(true);
        if (_question.Answers[_index] == _question.Answer)
        {
            answersCallback.image.sprite = goodSprite;
            answersCallback.GetComponentInChildren<TMP_Text>().text = "RIGHT";
            Questions.RandomDone = false;
            OnWon?.Invoke();
        }
        else
        {
            answersCallback.image.sprite = wrongSprite;
            answersCallback.GetComponentInChildren<TMP_Text>().text = "WRONG";
        }
    }
    #endregion


}
