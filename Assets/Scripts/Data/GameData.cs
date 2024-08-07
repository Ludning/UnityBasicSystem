using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public Dictionary<string, PcData> PcDatas;
    public Dictionary<string, EnemyData> EnemyDatas;
}
