using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldValueText;
    [SerializeField] private TMP_Text _jewelryValueText;
    [SerializeField] private TMP_Text _limitTimeText;

    public void Update()
    {
        _goldValueText.text = $"{IngameManager.UserDataManager.Gold}";
        _jewelryValueText.text = $"{IngameManager.UserDataManager.Jewelry}";
        // _limitTimeText.text = $"{IngameManager.UserDataManager.Gold}";
    }
}
