using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Idle = "Character Idle";
    private const string Move = "Character Move";
    private const string AttackMove = "Character Attack Move";
    private const string Attack = "Character Attack";
    
    [SerializeField] private Animation _animation;
    [SerializeField] private CraftingTable _craftingTable;
    
    private bool _hasHammer = false;
    private Animal _targetAnimal;

    private float _playerSpeed = 5f;
    private float _realfinalPlayerSpeed => _playerSpeed * IngameManager.UserDataManager.Value_PlayerSpeed;

    private void Update()
    {
        if (_hasHammer)
        {
            if (_targetAnimal == null)
            {
                _animation.Play(AttackMove);
                SearchTarget();
            }
            else
            {
                _animation.Play(AttackMove);
                Chasing();
            }
        }
        else
        {
            var targetHammer = _craftingTable.PlayerGetHammer();
            if (targetHammer == null)
            {
                _animation.Play(Idle);
                WaitHammer();
            }
            else
            {
                _animation.Play(Move);
                GetHammer(targetHammer);
            }
        }
    }

    private void WaitHammer()
    {
    }

    private void GetHammer(Hammer targetHammer)
    {
        if (targetHammer == null)
        {
            return;
        }

        var dir = targetHammer.transform.position - this.transform.position;
        dir = dir.normalized;

        this.transform.position += dir * _realfinalPlayerSpeed * Time.deltaTime;
        
        /////

        var distance = Math.Abs(Vector3.Distance(this.transform.position, targetHammer.transform.position));

        if (distance <= 0.02f)
        {
            _hasHammer = true;
            _craftingTable.ReleaseHammer(targetHammer);
            // 
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

        this.transform.position += dir * _realfinalPlayerSpeed * Time.deltaTime;
        
        /////

        var distance = Math.Abs(Vector3.Distance(this.transform.position, _targetAnimal.transform.position));

        if (distance <= 0.02f)
        {
            _animation.Play(Attack);
            Hammering();
        }
    }

    private void Hammering()
    {
        if (_targetAnimal == null)
        {
            return;
        }
        
        _hasHammer = false;
        
        this.transform.position = _targetAnimal.transform.position;
        // 골드 획득량
        IngameManager.UserDataManager.Gold += Mathf.RoundToInt(GameDataManager.GoldBalanceGameData.GetGainGoldRound(_craftingTable.Level) * IngameManager.UserDataManager.Value_AnimalGold);
        IngameManager.AnimalManager.BlowAwayAnimal(_targetAnimal);
    }
}
