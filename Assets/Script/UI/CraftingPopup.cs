using TMPro;
using UnityEngine;

public class CraftingPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private GameObject DisableButton;
    
    private CraftingTable _craftingTable;

    public void SetInfo(CraftingTable craftingTable)
    {
        _craftingTable = craftingTable;

        _levelText.text = $"{_craftingTable.Level} 레벨";

        UpdateStars();

        Enable();
    }

    private void UpdateStars()
    {
        
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
