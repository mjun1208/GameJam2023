using UnityEngine;

public static class GameDataManager
{
    public static GoldBalanceGameData GoldBalanceGameData { get; private set; }
    public static CraftingTableBalanceGameData CraftingTableBalanceGameData { get; private set; }
    
    public static void Load()
    {
        LoadGoldBalance();
        LoadCraftingTableBalance();
    }

    private static void LoadGoldBalance()
    {
        string pathName = "GoldBalance";
        
        var loadedJson = Resources.Load<TextAsset>($"Json/{pathName}"); 
        
        GoldBalanceGameData = JsonUtility.FromJson<GoldBalanceGameData>(loadedJson.ToString());
        GoldBalanceGameData.SetData();
    }
    
    private static void LoadCraftingTableBalance()
    {
        string pathName = "CraftingTableBalance";
        
        var loadedJson = Resources.Load<TextAsset>($"Json/{pathName}"); 
        
        CraftingTableBalanceGameData = JsonUtility.FromJson<CraftingTableBalanceGameData>(loadedJson.ToString());
    }
}
