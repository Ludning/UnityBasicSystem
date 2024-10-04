using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    private const string CSV_DATA_PATH = "CsvDataTable";
    private const string JSON_DATA_PATH = "JsonDataTable";

    //private const string CSV_DATA_TABLE_NAME = "ChapterDataTable";
    //private const string JSON_DATA_TABLE_NAME = "ChapterDataTable";

    private Dictionary<string, object> dataDictionary = new Dictionary<string, object>();
    
    /*private GameData GameData;
    private Dictionary<string, IUserData> UserDatas;
    private AssetPathData AssetPathData;*/

    protected override void Init()
    {
        base.Init();

        //LoadCsvDataTable("CsvDataTable", "GameData");
        LoadJsonDataTable<GameData>("JsonDataTable", "GameData");
    }

    private void LoadCsvDataTable<T>(string dataPath, string dataTableName)
    {
        var parsedDataTable = CSVReader.Read<T>($"{CSV_DATA_PATH}/{dataTableName}");

        /*foreach (var data in parsedDataTable)
        {
            var chapterData = new ChapterData
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                TotalStages = Convert.ToInt32(data["total_stages"]),
                ChapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                ChapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };

            ChapterDataTable.Add(chapterData);
        }
        dataDictionary.Add();*/
    }
    private void LoadJsonDataTable<T>(string dataPath, string dataTableName)
    {
        var jsonFile = Resources.Load<TextAsset>($"{JSON_DATA_PATH}/{dataTableName}");
        var parsedDataTable = JsonConvert.DeserializeObject<T>(jsonFile.text);

    }
    public ChapterData GetData<T>(string key)
    {
        if (dataDictionary.TryGetValue(typeof(T), out var value))
        {
        }
        
        //return ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault();
    }
}
