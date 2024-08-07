using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGoodsData : IUserData
{
    //골드등 유저 소지 데이터
    public long Gold { get; set; }
    
    public void SetDefaultData()
    {
        Logger.Log($"{GetType()}::SetDefaultData");
        Gold = 0;
    }
    public bool LoadData()
    {
        Logger.Log($"{GetType()}::LoadData");

        bool result = false;

        try
        {
            Gold = long.Parse(PlayerPrefs.GetString("Gold"));
            result = true;
            
            Logger.Log($"Gold:{Gold}");
        }
        catch (Exception e)
        {
            Logger.Log($"Load failed ({e.Message})");
        }
        return result;
    }
    public bool SaveData()
    {
        Logger.Log($"{GetType()}::SaveData");

        bool result = false;

        try
        {
            PlayerPrefs.SetString("Gold", Gold.ToString());
            //PlayerPrefs.Save();
            result = true;
            
            Logger.Log($"Gold:{Gold}");
        }
        catch (Exception e)
        {
            Logger.Log($"Load failed ({e.Message})");
        }
        return result;
    }
}
