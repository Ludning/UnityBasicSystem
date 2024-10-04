using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadCsvData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataTableManager.Instance.LoadCsvDataTable();
        DataTableManager.Instance.Load();
    }
}
