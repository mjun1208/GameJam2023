using TMPro;
using UnityEngine;

public class CraftingPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _levelUpCost;
    [SerializeField] private GameObject DisableButton;
    
    private CraftingTable _craftingTable;

    public void SetInfo(CraftingTable craftingTable)
    {
        _craftingTable = craftingTable;

        _levelText.text = $"{_craftingTable.Level} 레벨";
        _levelUpCost.text = $"{GameDataManager.GoldBalanceGameData.GetNeedGoldRound(_craftingTable.Level)}";

        UpdateStars();

        Enable();
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
