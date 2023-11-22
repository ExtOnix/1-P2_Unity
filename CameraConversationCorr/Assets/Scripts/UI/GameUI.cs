using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] AnswersButton answers = null;
    [SerializeField] Transform answersContent = null;
    [SerializeField] TMP_Text questionText = null;
    [SerializeField] DialogSettings dialogSettings = null;


    public bool IsValid => answers && answersContent;

    private void Awake()
    {
        dialogSettings.OnNext += (e) => GenerateDialog();
    }

    private void Start()
    {
        dialogSettings.StartDialog();
    }

    void GenerateDialog()
    {
        questionText.text = dialogSettings.CurrentDialog.Quote;
        for (int i = 0; IsValid && i < dialogSettings.CurrentDialog.Length; i++)
        {
            int _index = i;
            AnswersButton _button = Instantiate(answers, answersContent);
            _button.Init($"{dialogSettings.CurrentDialog[_index].Quote}", NextDialog);
        }
    }


    void NextDialog()
    {
        ClearAnswers(answersContent);
        dialogSettings.SetNextDialog();

    }

    void ClearAnswers(Transform _tr)
    {
        for (int i = 0; i < _tr.childCount; i++)
        {
            Destroy(_tr.GetChild(i).gameObject);
        }
    }




}
