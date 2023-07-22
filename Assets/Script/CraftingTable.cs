using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingTable : MonoBehaviour, IPointerClickHandler
{
    public int Level { get; set; }

    public void LevelUp()
    {
        Level += 1;

        int reward = GameDataManager.CraftingTableBalanceGameData.GetRewardJewelry(Level);
        if (reward > 0)
        {
            IngameManager.UserDataManager.Jewelry += reward;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IngameManager.CraftingPopup.SetInfo(this);
    }
}
