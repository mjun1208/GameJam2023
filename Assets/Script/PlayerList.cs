using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    [SerializeField] Player prefab;
    int curPlayerCount = 0;

    List<Player> players = new List<Player>();

    void Start()
    {
        prefab.gameObject.SetActive(false);
    }

    void Update()
    {
        AddIfRequired();
    }

    void AddIfRequired()
    {
        if (curPlayerCount < IngameManager.UserDataManager.Value_SpawnPlayer)
        {
            var player = Instantiate(prefab);
            player.gameObject.SetActive(true);
            players.Add(player);
            curPlayerCount++;
        }
    }
}
