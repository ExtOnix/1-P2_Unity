using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainUI : MonoBehaviour
{
    public event Action OnPlayButton = null, OnQuitButton = null, OnEscapeButton = null;
    [SerializeField] Button playButton = null;
    [SerializeField] Button quitButton = null;
    [SerializeField] Button escapeButton = null;
    [SerializeField] GameObject mainGamePage = null;

    public bool IsValidUI => playButton && quitButton && escapeButton;

    void Start() => InitUI();

    private void Awake()
    {
        OnPlayButton += OnPlayUI;
        OnQuitButton += OnQuitUI;
        OnEscapeButton += OnEscapeGame;
    }

    void HidePage(GameObject _page)
    {
        _page?.SetActive(false);
    }

    void ShowPage(GameObject _page)
    {
        _page?.SetActive(true);
    }
    void InitUI()
    {
        if (!IsValidUI)
        {
            Debug.LogError("UI -> Missing elements");
            return;
        }
        playButton.onClick.AddListener(() => OnPlayButton?.Invoke());
        quitButton.onClick.AddListener(() => OnQuitButton?.Invoke());
    }

    void InitGame()
    {
        if (!IsValidUI)
        {
            Debug.LogError("UI -> Missing elements");
            return;
        }
        escapeButton.onClick.AddListener(() => OnEscapeButton?.Invoke());
        HidePage(mainGamePage);
        escapeButton?.gameObject.SetActive(true);
    }

    void OnPlayUI()
    {
        InitGame();
    }

    void OnEscapeGame()
    {
        ShowPage(mainGamePage);
        escapeButton?.gameObject.SetActive(false);
    }

    void OnQuitUI()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

    private void OnDestroy()
    {
        OnPlayButton = null;
        OnQuitButton = null;
    }
}
