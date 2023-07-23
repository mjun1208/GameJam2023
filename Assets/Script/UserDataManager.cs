public class UserDataManager
{
    // 이것들만 저장하면 행복해질까..?

    public int Gold { get; set; } = 0;
    public int Jewelry { get; set; }
    
    public int Stage { get; set; }


    //여긴.. 지옥. 이다.
    public int Value_AddAnimal { get; private set; } = 0;
    public float Value_HammerSpawnDelay { get; private set; } = 1;
    public float Value_AnimalGold { get; private set; } = 1;
    public int Value_SpawnPlayer { get; private set; } = 1;
    public float Value_PlayerSpeed { get; private set; } = 1;

    public void Purchase(Quest quest)
    {
        switch (quest.QuestType)
        {
            case QuestType.AddAnimal:
                Value_AddAnimal += (int)quest.GrowValue;
                break;
            case QuestType.HammerSpawnDelay:
                Value_HammerSpawnDelay *= (int)quest.GrowValue;
                break;
            case QuestType.AnimalGold:
                Value_AnimalGold += (int)quest.GrowValue;
                break;
            case QuestType.SpawnPlayer:
                Value_SpawnPlayer += (int)quest.GrowValue;
                break;
            case QuestType.PlayerSpeed:
                Value_PlayerSpeed += (int)quest.GrowValue;
                break;
        }
    }
}
