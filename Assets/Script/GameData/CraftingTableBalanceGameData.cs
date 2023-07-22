using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class CraftingTableBalance
{
    public int StarCount;
    public int Level;
    public int RewardJewelry;
}

[Serializable]
public class CraftingTableBalanceGameData
{
    public List<CraftingTableBalance> DataList;

    public CraftingTableBalance GetData(int currentLevel)
    {
        int lastDataLevel = DataList.Where(x => x.Level < currentLevel).Max(x => x.Level);
        var data = DataList.Find(x=> x.Level == lastDataLevel);

        return data;
    }

    public int GetRewardJewelry(int level)
    {
        var data = DataList.Find(x => x.Level == level);
        if (data != null)
        {
            return data.RewardJewelry;
        }

        return 0;
    }
}
