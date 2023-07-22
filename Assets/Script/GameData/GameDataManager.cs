using UnityEngine;

public static class GameDataManager
{
    public static GoldBalanceGameData GoldBalanceGameData { get; private set; }
    
    public static void Load()
    {
        string pathName = "GoldBalance";
        
        var loadedJson = Resources.Load<TextAsset>($"Json/{pathName}"); 
        
        GoldBalanceGameData = JsonUtility.FromJson<GoldBalanceGameData>(loadedJson.ToString());
        GoldBalanceGameData.SetData();
    }
}
