using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    /*public static List<Dictionary<string, object>> Read(string file)
    {
        var list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }*/
    /*public static T Read<T>(string file) where T : IDataRepository, new()
    {
        var result = new T();
        TextAsset data = Resources.Load(file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return result;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            for (var k = 0; k < header.Length && k < values.Length; k++)
            {
                string value = values[k];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                /*object finalvalue = value;
                if (int.TryParse(value, out int n))
                    finalvalue = n;
                else if (float.TryParse(value, out float f))
                    finalvalue = f;#1#

                result.FromCsv(new string[] { header[k], value });
            }
        }
        return result;
    }*/

    public static T Read<T>(string file) where T : IDataRepository, new()
    {
        var result = new T();
        var reader = Resources.Load(file) as TextAsset;
        
        
        
        // 첫 번째 줄 읽기 (필요에 따라 헤더를 무시할 수 있음)
        var lines = Regex.Split(reader.text, LINE_SPLIT_RE);
        if (lines.Length <= 1) return result;

        // 데이터를 파싱하여 T 타입의 인스턴스를 생성
        /*var values = lines[0].Split(',');
        var dataItem = new T();
        dataItem.FromCsv(values);*/
        
        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            for (var k = 0; k < header.Length && k < values.Length; k++)
            {
                string value = values[k];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
            }
        }
        result.FromCsv(new string[] { header[k], value });

        return dataItem;



        var aa = new StreamReader(file);
        var line = aa.ReadLine();
    }
}