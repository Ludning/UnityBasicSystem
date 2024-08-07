using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataTableManager_Backup : SingletonBehaviour<DataTableManager_Backup>
{
    private const string DATA_PATH = "DataTable";

    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";
    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    protected override void Init()
    {
        base.Init();

        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        foreach (var data in parsedDataTable)
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
    }

    public ChapterData GetChapterData(int chapterNo)
    {
        return ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault();
    }
}