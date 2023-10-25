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
    public static  event Action<Questions[]> OnQuestion = null;

    void Start()
    {
        MainUI.OnPlayButton += () => Init("tv_cinema", "facile");
        Debug.Log("Test");
    }

    IEnumerator Init(string _category, string _difficulty)
    {
        Debug.Log("Test2");
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
            Questions[] _questions = JsonConvert.DeserializeObject<Questions[]>(_request.downloadHandler.text);
            Debug.Log(_questions.ToString());
            OnQuestion?.Invoke(_questions);
        }

    }
}
