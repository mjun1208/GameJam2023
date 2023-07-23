using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public void AddGold()
    {
        IngameManager.UserDataManager.Gold += 10000;
    }
}
