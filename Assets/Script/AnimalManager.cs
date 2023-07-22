using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Task = System.Threading.Tasks.Task;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] private Animal _animal;

    private List<Animal> _animals = new List<Animal>();
    private bool vow = false;
    private int _limitCount = 25;

    private void Awake()
    {
        _animal.gameObject.SetActive(false);
    }

    private void Start()
    {
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
        
        await Task.Delay(Random.Range(100, 400));
        vow = false;
        SpawnAnimal();
        SpawnAnimal();
        SpawnAnimal();
    }

    private void SpawnAnimal()
    {
        if (_animals.Count > _limitCount)
        {
            return;
        }
        
        var dir = Random.Range(0, 2) == 0 ? 1 : -1;

        var newAnimal = Instantiate(_animal, new Vector3(Random.Range(-5f, 5f), 15 * dir, 0), Quaternion.identity);
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
        // await 
        ReleaseAnimal(animal);
    }
    
    // 해당 작업대와 가장 가까운 동물  
    public Animal GetNearAnimal()
    {
        var minDistance = float.MaxValue;
        Animal targetAnimal = null;

        foreach (var animal in _animals)
        {
            var distance = Math.Abs(Vector3.Distance(Vector3.zero, animal.transform.position));

            if (distance < minDistance)
            {
                minDistance = distance;
                targetAnimal = animal;
            }
        }

        return targetAnimal;
    }
}
