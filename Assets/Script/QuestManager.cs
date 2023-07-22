using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // 귀찮으니까 코드에 다 박자..
    
    public List<Quest> Stage_1_QuestList = new List<Quest>()
    {
        new Quest(QuestType.AddAnimal, "오리 수 증가", 5, 30),
        new Quest(QuestType.HammerSpawnDelay, "종이망치 제작 속도 줄이기", 0.5f, 70),
        new Quest(QuestType.AnimalGold, "오리 몸값 높이기", 2, 280),
        new Quest(QuestType.SpawnPlayer, "조력자 코기 소환", 1, 1000),
        new Quest(QuestType.PlayerSpeed, "코기 이동 속도 높이기", 1.3f, 3000),
    }; 
}

public class Quest
{
    public QuestType QuestType;
    public string QuestDesc;
    public float GrowValue;
    public int NeedGold;

    public bool IsClear = false;

    public Quest(QuestType questType, string questDesc, float growValue, int needGold)
    {
        QuestType = questType;
        QuestDesc = questDesc;
        GrowValue = growValue;
        NeedGold = needGold;
    }
}

public enum QuestType
{
    AddAnimal,
    HammerSpawnDelay,
    AnimalGold,
    SpawnPlayer,
    PlayerSpeed,
}