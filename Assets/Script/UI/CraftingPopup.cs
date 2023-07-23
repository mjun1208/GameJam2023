using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPopup : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private RectTransform _canvas;
    
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _levelUpCost;
    [SerializeField] private GameObject DisableButton;
    [SerializeField] private List<Star> _starList;
    
    [SerializeField] private GameObject _levelUpButton;
    [SerializeField] private GameObject _maxText;

    [SerializeField] private Slider _expProgressBar;
    
    private RectTransform _rectTransform;
    private CraftingTable _craftingTable;

    private bool IsMaxLevel = false;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetInfo(CraftingTable craftingTable)
    {
        _craftingTable = craftingTable;

        _levelText.text = $"{_craftingTable.Level} 레벨";
        _levelUpCost.text = $"{GameDataManager.GoldBalanceGameData.GetNeedGoldRound(_craftingTable.Level)}";

        UpdateStars();

        var nextStarLevel  = GameDataManager.CraftingTableBalanceGameData.GetNextLevel(_craftingTable.Level);
        int currentDataLevel = 0;
        if (GameDataManager.CraftingTableBalanceGameData.GetData(_craftingTable.Level) != null)
        {
            currentDataLevel = GameDataManager.CraftingTableBalanceGameData.GetData(_craftingTable.Level).Level;
        }

        _expProgressBar.value = (float)(_craftingTable.Level - currentDataLevel) / (float)(nextStarLevel - currentDataLevel);
        IsMaxLevel = _craftingTable.Level == GameDataManager.GoldBalanceGameData.MaxLevel;
        _levelUpButton.SetActive(!IsMaxLevel);
        _maxText.SetActive(IsMaxLevel);
        
        Enable();
    }

    private void Update()
    {
        if (_craftingTable != null)
        {
            Vector2 ViewportPosition = _mainCamera.WorldToViewportPoint(_craftingTable.transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ((ViewportPosition.x * _canvas.sizeDelta.x) - (_canvas.sizeDelta.x * 0.5f)),
                ((ViewportPosition.y * _canvas.sizeDelta.y) - (_canvas.sizeDelta.y * 0.5f)) + 20);
            _rectTransform.anchoredPosition = WorldObject_ScreenPosition;
            
            // this.transform.position =
            //     new Vector3(_craftingTable.transform.position.x, _craftingTable.transform.position.y - 20, this.transform.position.z);
        }
    }

    private void UpdateStars()
    {
        var data = GameDataManager.CraftingTableBalanceGameData.GetData(_craftingTable.Level);

        if (data == null)
        {
            for (int i = 0; i < _starList.Count; i++)
            {
                _starList[i].IsActive = false;
            }
        }
        else
        {
            for (int i = 0; i < _starList.Count; i++)
            {
                _starList[i].IsActive = i + 1 <= data.StarCount;
            }
        }
    }

    public void OnClickLevelUp()
    {
        var needGold = GameDataManager.GoldBalanceGameData.GetNeedGoldRound(_craftingTable.Level);
        if (IngameManager.UserDataManager.Gold < needGold)
        {
            return;
        }

        IngameManager.UserDataManager.Gold -= needGold;
        _craftingTable.LevelUp();
        SetInfo(_craftingTable);

        IsMaxLevel = _craftingTable.Level == GameDataManager.GoldBalanceGameData.MaxLevel;
        _levelUpButton.SetActive(!IsMaxLevel);
        _maxText.SetActive(IsMaxLevel);
    }

    public void Enable()
    {
        DisableButton.SetActive(true);
        this.gameObject.SetActive(true);
    }

    public void Disable()
    {
        DisableButton.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
