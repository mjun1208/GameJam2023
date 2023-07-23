using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingTable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Hammer _baseHammer;
    public int Level { get; set; } = 1;
    private bool _isSpawnDelay = false;
    private List<Hammer> _hammerList = new List<Hammer>();

    public int HammerCount => _hammerList.Count;

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
        
        // 해머 생성 딜레이 (제작 속도)
        await Task.Delay(5000);
        _isSpawnDelay = false;

        var newHammer = GameObject.Instantiate(_baseHammer, this.transform.position, Quaternion.identity);
        newHammer.gameObject.SetActive(true);
        _hammerList.Add(newHammer);
    }

    public Hammer PlayerGetHammer()
    {
        if (HammerCount == 0)
        {
            return null;
        }
        else
        {
            return _hammerList.FirstOrDefault();
        }
    }

    public void ReleaseHammer(Hammer hammer)
    {
        _hammerList.Remove(hammer);
        Destroy(hammer.gameObject);
    }
}
