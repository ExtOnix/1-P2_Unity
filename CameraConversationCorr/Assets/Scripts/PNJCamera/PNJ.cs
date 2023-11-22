using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PNJDialogCameraSystem))]
public class PNJ : MonoBehaviour
{
    [SerializeField] PNJDialogCameraSystem pnjDialogCameraSystem = null;
    //[SerializeField] DialogSettings dialogData = null;


    private void Start()
    {
        Init();
    }
    void Init()
    {
        //dialogData.OnNext += (d) =>
        //{
        //pnjDialogCameraSystem.SetLookAt(d.IsPNJ)
        //UpdateUI();
        //}
        pnjDialogCameraSystem = GetComponent<PNJDialogCameraSystem>();
        pnjDialogCameraSystem.InitCameraDialog();
        //dialogData.StartDialog();
    }
}
