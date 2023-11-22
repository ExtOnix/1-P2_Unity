using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;

public class NetworkAPI : MonoBehaviour
{
    public static  event Action<Quizz> OnQuizz = null;

    #region f/p
    public static string category = "tv_cinema";
    public static string difficulty = "facile";
    #endregion

    #region Unity
    void Start()
    {
        MainUI.OnPlayButton += () => StartCoroutine(Init(category, difficulty));
        GameUI.OnWon += () => StartCoroutine(Init(category, difficulty));
        GameUI.OnRenewQuestion += () => StartCoroutine(Init(category, difficulty));
    }
    #endregion

    #region Methods
    public IEnumerator Init(string _category, string _difficulty)
    {
        yield return StartCoroutine(GetQuestions(_category,_difficulty));
    }
    IEnumerator GetQuestions(string _category, string _difficulty)
    {
        UnityWebRequest _request = UnityWebRequest.Get(API.Questions(_category, _difficulty));
        yield return _request.SendWebRequest();
        if (_request.result != UnityWebRequest.Result.Success)
            Debug.LogError("DOWNLOAD FAILED");
        else
        {
            Quizz _questions = JsonConvert.DeserializeObject<Quizz>(_request.downloadHandler.text);
            OnQuizz?.Invoke(_questions);
        }

    }
    #endregion
}
