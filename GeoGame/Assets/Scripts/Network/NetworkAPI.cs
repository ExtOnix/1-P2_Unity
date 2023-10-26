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

    void Start()
    {
        MainUI.OnPlayButton += () => StartCoroutine(Init("tv_cinema", "facile"));
        GameUI.OnWon += () => StartCoroutine(Init("tv_cinema", "facile"));
        Debug.Log("Test");
    }

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
}
