using UnityEngine;

public class Hammer : MonoBehaviour
{   
    private float delay = 0.1f;
    private float time = 0f;
    
    public void Update()
    {
        time += Time.deltaTime;
        if (time > delay)
        {
            Hammering();
            time = 0f;
        }
    }

    private void Hammering()
    {
        var targetAnimal = IngameManager.AnimalManager.GetNearAnimal();
        if (targetAnimal == null)
        {
            return;
        }
        
        this.transform.position = targetAnimal.transform.position;
        
        IngameManager.AnimalManager.BlowAwayAnimal(targetAnimal);
    }
}
