using System;
using TMPro;
using UnityEngine;

public class CraftingPopup : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private RectTransform _canvas;
    
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _levelUpCost;
    [SerializeField] private GameObject DisableButton;

    private RectTransform _rectTransform;
    private CraftingTable _craftingTable;
    
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
