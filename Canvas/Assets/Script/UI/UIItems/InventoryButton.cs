using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Button inventoryButton = null;
    [SerializeField] TMP_Text inventoryText = null;

    public bool IsValid => inventoryButton && inventoryText;

    public void Init(string _label, Action _todo)
    {
        if (!IsValid)
            return;
        inventoryText.text = _label;
        inventoryButton.onClick.AddListener(() => _todo?.Invoke());
    }
}
