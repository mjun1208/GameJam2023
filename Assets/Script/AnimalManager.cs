using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
using Task = System.Threading.Tasks.Task;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] private Animal _animal;

    private List<Animal> _animals = new List<Animal>();
    private bool vow = false;
    private int _limitCount = 25;

    private int _spawnCount = 1;
    private int _realFinalSpawnCount => _spawnCount + IngameManager.UserDataManager.Value_AddAnimal;

    private void Awake()
    {
        _animal.gameObject.SetActive(false);
    }

    private void Update()
    {
        SpawnVow();
    }

    private async void SpawnVow()
    {
        if (vow)
        {
            return;
        }

        vow = true;
        
        await Task.Delay(2000);
        vow = false;

        // 초 당 화면에 등장 오리 수
        for (int i = 0; i < _realFinalSpawnCount; i++)
        {
            SpawnAnimal();
        }
    }

    private void SpawnAnimal()
    {
        if (_animals.Count > _limitCount)
        {
            return;
        }
        
        var dir = Random.Range(0, 2) == 0 ? 1 : -1;

        var newAnimal = Instantiate(_animal, new Vector3(Random.Range(-5f, 5f), 11 * dir, 0), Quaternion.identity);
        newAnimal.gameObject.SetActive(true);
        _animals.Add(newAnimal);
    }

    private void ReleaseAnimal(Animal animal)
    {
        _animals.Remove(animal);
        Destroy(animal.gameObject);
    }

    public async void BlowAwayAnimal(Animal animal)
    {
        Sequence seq = DOTween.Sequence();
        seq.Join(animal.transform.DOShakeRotation(2f, 1000f));
        seq.Join(animal.transform.DOMoveX(Random.Range(-10,10), 1f));
        seq.Join(animal.transform.DOMoveY(Random.Range(-10,10), 1f));

        await seq.Play().AsyncWaitForCompletion();
        ReleaseAnimal(animal);
    }
    
    public Animal GetNearAnimal(Vector3 target)
    {
        var minDistance = float.MaxValue;
        Animal targetAnimal = null;

        foreach (var animal in _animals)
        {
            var distance = Math.Abs(Vector3.Distance(target, animal.transform.position));

            if (distance < minDistance)
            {
                minDistance = distance;
                targetAnimal = animal;
            }
        }

        return targetAnimal;
    }
}
