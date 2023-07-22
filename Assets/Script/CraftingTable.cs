using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingTable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Hammer _baseHammer;
    public int Level { get; set; } = 1;
    private bool _isSpawnDelay = false;

    private void Awake()
    {
        _baseHammer.gameObject.SetActive(false);
    }

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

    private void Update()
    {
        SpawnHammer();
    }

    public async void SpawnHammer()
    {
        if (_isSpawnDelay)
        {
            return;
        }

        _isSpawnDelay = true;
        
        await Task.Delay(1000);
        _isSpawnDelay = false;

        var newHammer = GameObject.Instantiate(_baseHammer, this.transform.position, Quaternion.identity);
        newHammer.gameObject.SetActive(true);
    }
}
