using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LevelMgr : Singleton<LevelMgr>
{  
    //读取关卡csv，根据表格生成角色和配置站位 
    public void LevelGenerate(string levelName)
    {
        var csvreader = new CSVreader();
        Dictionary<string, int> charaInfo = csvreader.ReadLevel(levelName);
        ScenesMgr.Instance().LoadScean(levelName, () => 
        {
            foreach (KeyValuePair<string, int> entry in charaInfo)
            {
                //使用加载角色的方法分配角色站位

            }

        
        });


    }



}

public class CSVreader
{
    public string fileName;

    //获取csv关卡信息，存入词典备用
    public Dictionary<string,int> ReadLevel(string fileName)
    {    
        string path = "CSV/Level/" + fileName;
        TextAsset csvFile = ResMgr.Instance().Load<TextAsset>(path);
        Dictionary<string,int> CharaInfo = new Dictionary<string,int>();

        if (csvFile == null ) 
        {
            Debug.LogError($"CSV 文件未找到: {fileName}.csv");
            return null;
        }

        StringReader reader = new StringReader(csvFile.text);
        bool isFirstLine = true;

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); //每次读取都会切换到下一行
            string[] values = line.Split(',');

            if (isFirstLine) // 跳过标题行
            {
                isFirstLine = false;
                continue;
            }

            if (values.Length >= 2) // 至少有 角色 和 位置
            {
                string characterName = values[0].Trim(); // 角色名
                int position; // 解析坐标

                if (int.TryParse(values[1].Trim(), out position))
                {
                    CharaInfo[characterName] = position;
                }
                else
                {
                    Debug.LogError($"无法解析 {characterName} 的位置数据: {values[1]}");
                }

            }
        }

        return CharaInfo;
    }
}
