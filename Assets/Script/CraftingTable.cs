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

    private float _createDelay = 5;
    private float _realFinalCreateDelay => _createDelay * IngameManager.UserDataManager.Value_HammerSpawnDelay;

    private float _createTime = 0f;

    public int HammerCount => _hammerList.Count;

    private void Awake()
    {
        _baseHammer.gameObject.SetActive(false);
    }

    public void LevelUp()
    {
        if (Level == GameDataManager.GoldBalanceGameData.MaxLevel)
        {
            return;
        }
        
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
        _createTime += Time.deltaTime;

        if (_createTime > _createDelay * IngameManager.UserDataManager.Value_HammerSpawnDelay)
        {
            _createTime = 0f;

            var newHammer = GameObject.Instantiate(_baseHammer, this.transform.position, Quaternion.identity);
            newHammer.gameObject.SetActive(true);
            _hammerList.Add(newHammer);
        }
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
