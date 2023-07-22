using System.Collections.Generic;
using System.Linq;

public class GoldBalance
{
    public int Level;
    public float NeedGold;
    public int NeedGoldRound;
    public float GainGold;
    public int GainGoldRound;
}

public class GoldBalanceGameData
{
    public List<GoldBalance> DataList;

    public int MaxLevel { get; private set; }
    
    public void SetData()
    {
        MaxLevel = DataList.Max(x => x.Level);
    }

    public int GetNeedGoldRound(int level)
    {
        var goldData = DataList.Find(x => x.Level == level);
        if (goldData == null)
        {
            return 0;
        }

        return goldData.NeedGoldRound;
    }
    
    public int GetGainGoldRound(int level)
    {
        var goldData = DataList.Find(x => x.Level == level);
        if (goldData == null)
        {
            return 0;
        }

        return goldData.GainGoldRound;
    }
}