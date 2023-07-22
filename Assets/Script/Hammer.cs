using System;
using UnityEngine;

public class Hammer : MonoBehaviour
{   
    [SerializeField] private CraftingTable _craftingTable;
    private Animal _targetAnimal;

    private void Update()
    {
        if (_targetAnimal == null)
        {
            SearchTarget();
        }
        else
        {
            Chasing();
        }
    }

    private void SearchTarget()
    {
        var targetAnimal = IngameManager.AnimalManager.GetNearAnimal(this.transform.position);
        if (targetAnimal == null)
        {
            return;
        }

        _targetAnimal = targetAnimal;
    }

    private void Chasing()
    {
        if (_targetAnimal == null)
        {
            return;
        }

        var dir = _targetAnimal.transform.position - this.transform.position;
        dir = dir.normalized;

        this.transform.position += dir * 5f * Time.deltaTime;
        
        /////

        var distance = Math.Abs(Vector3.Distance(this.transform.position, _targetAnimal.transform.position));

        if (distance <= 0.02f)
        {
            Hammering();
        }
    }

    private void Hammering()
    {
        if (_targetAnimal == null)
        {
            return;
        }
        
        this.transform.position = _targetAnimal.transform.position;
        IngameManager.UserDataManager.Gold += GameDataManager.GoldBalanceGameData.GetGainGoldRound(_craftingTable.Level);
        Destroy(this.gameObject);
        IngameManager.AnimalManager.BlowAwayAnimal(_targetAnimal);
    }
}
