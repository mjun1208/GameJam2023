using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataManager
{
    public static void Load()
    {
        string pathName = "vow";
        
        var loadedJson = Resources.Load<TextAsset>($"{pathName}.json"); 
        
        // var vow = JsonUtility.FromJson<Type.GetType(pathName)>(loadedJson.ToString());
    }
}
