using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainUI : MonoBehaviour
{
    public static  event Action OnPlayButton = null, OnQuitButton = null, OnMenuButton = null;

    [SerializeField] Button playButton = null;
    [SerializeField] Button quitButton = null;
    [SerializeField] Button menuButton = null;
    [SerializeField] GameObject gamePage = null;
    [SerializeField] GameObject mainPage = null;
    [SerializeField] Dropdown category = null;

    public bool IsValidUI => playButton && quitButton;

    void Awake()
    {
        OnPlayButton += OnPlayGame;
        OnMenuButton += OnGoMenu;
        OnQuitButton += OnQuitGame;
    }

    void Start() => InitUI();

    void InitUI()
    {
        if (!IsValidUI)
        {
            Debug.LogError("UI -> Missing elements");
            return;
        }
        playButton.onClick.AddListener(() => OnPlayButton?.Invoke());
        quitButton.onClick.AddListener(() => OnQuitButton?.Invoke());
        menuButton.onClick.AddListener(() => OnMenuButton?.Invoke());
    }

    void OnPlayGame()
    {
        HidePage(mainPage);
        ShowPage(gamePage);
    }

    void OnGoMenu()
    {
        HidePage(gamePage);
        ShowPage(mainPage);
    }

    void OnQuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ShowPage(GameObject _page)
    {
        _page?.SetActive(true);
    }

    public void HidePage(GameObject _page)
    {
        _page?.SetActive(false);
    }

    public void ChooseCategory()
    {
        
    }
}
