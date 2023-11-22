using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static event Action OnWon = null;
    public static event Action OnLoose = null;
    public static event Action OnRenewQuestion = null;
    #region f/p
    [SerializeField] AnswerButtons answers = null;
    [SerializeField] Transform answersContent = null;
    [SerializeField] TMP_Text questionText = null;
    [SerializeField] TMP_Text scoreText = null;
    [SerializeField] TMP_Text bestScoreText = null;

    [SerializeField] Sprite goodSprite = null;
    [SerializeField] Sprite wrongSprite = null;

    [SerializeField] int score = 0;

    [SerializeField] Button answersCallback = null;

    [SerializeField] protected GameInfos gameInfos = null;
    public bool IsValid => answers && answersContent;
    #endregion

    #region Unity
    private void Awake()
    {
        MainUI.OnPlayButton += ClearScore;
        NetworkAPI.OnQuizz += GenerateQuestion;
        OnWon += WinPoint;
        OnLoose += LoosePoint;
        NetworkAPI.OnQuizz += (q) => ShowScore();
        OnLoose += ShowScore;
        NetworkAPI.OnQuizz += (q) => UpdateBestScore();
    }

    #endregion

    #region Methods
    void GenerateQuestion(Quizz quizz)
    {
        ClearAnswers(answersContent);
        answersCallback.gameObject.SetActive(false);
        if (!gameInfos.AllIDs.Contains(quizz.Quizzes[0]._ID))
            gameInfos.AllIDs.Add(quizz.Quizzes[0]._ID);
        else
        {
            OnRenewQuestion?.Invoke();
            return;
        }

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

    void ShowScore()
    {
            scoreText.text = score.ToString();
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
            OnLoose?.Invoke();
        }
        Debug.Log(score);
    }

    void WinPoint()
    {
        score++;
    }

    void LoosePoint()
    {
        score = score != 0 ? score - 1 :0 ;
    }
    void ClearScore()
    {
        score = 0;
    }

    void UpdateBestScore()
    {
        gameInfos.BestScore = gameInfos.BestScore <= score ? score : gameInfos.BestScore;
        bestScoreText.text = gameInfos.BestScore.ToString();
    }

    #endregion


}
