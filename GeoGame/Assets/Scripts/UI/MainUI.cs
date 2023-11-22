using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainUI : MonoBehaviour
{
    public static  event Action OnPlayButton = null, OnQuitButton = null, OnMenuButton = null, OnCategoryMenu = null, OnDifficultyMenu = null;

    #region f/p
    [SerializeField] Button playButton = null;
    [SerializeField] Button quitButton = null;
    [SerializeField] Button menuButton = null;
    [SerializeField] GameObject gamePage = null;
    [SerializeField] GameObject mainPage = null;
    [SerializeField] Dropdown category = null;
    [SerializeField] Dropdown difficulty = null;

    public bool IsValidUI => playButton && quitButton && menuButton && category && difficulty;
    #endregion

    #region Unity
    void Awake()
    {
        OnPlayButton += OnPlayGame;
        OnMenuButton += OnGoMenu;
        OnQuitButton += OnQuitGame;
        OnCategoryMenu += ChooseCategory;
        OnDifficultyMenu += ChooseDifficulty;
    }

    void Start() => InitUI();
    #endregion

    #region Methods
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
        category.onValueChanged.AddListener((i) => OnCategoryMenu?.Invoke());
        difficulty.onValueChanged.AddListener((i) => OnDifficultyMenu?.Invoke());
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
        switch (category.value)
        {
            case 0:
                NetworkAPI.category = DropdownUtils.TV_CINEMA;
                break;
            case 1:
                NetworkAPI.category = DropdownUtils.ART;
                break;
            case 2:
                NetworkAPI.category = DropdownUtils.VIDEO_GAMES;
                break;
            case 3:
                NetworkAPI.category = DropdownUtils.MUSIC;
                break;
            case 4:
                NetworkAPI.category = DropdownUtils.KNOWLEDGE;
                break;
            case 5:
                NetworkAPI.category = DropdownUtils.SPORT;
                break;
            case 6:
                NetworkAPI.category = DropdownUtils.RANDOM_CAT;
                break;
            default:
                break;
        }
    }

    public void ChooseDifficulty()
    {
        switch (difficulty.value)
        {
            case 0:
                NetworkAPI.difficulty = DropdownUtils.EASY;
                break;
            case 1:
                NetworkAPI.difficulty = DropdownUtils.NORMAL;
                break;
            case 2:
                NetworkAPI.difficulty = DropdownUtils.HARD;
                break;
            case 3:
                NetworkAPI.difficulty = DropdownUtils.RANDOM_DIFFICULTY;
                break;
            default:
                break;
        }
    }
    #endregion
}
