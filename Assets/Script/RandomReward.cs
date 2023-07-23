using UnityEngine;

public class RandomReward : MonoBehaviour
{
    public void OnClickRandomReward()
    {
        // IngameManager.UserDataManager.Gold +=;
        IngameManager.UserDataManager.Jewelry += 10;
    }
}
