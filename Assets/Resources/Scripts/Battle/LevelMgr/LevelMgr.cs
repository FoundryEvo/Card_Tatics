using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LevelMgr : Singleton<LevelMgr>
{  
    //��ȡ�ؿ�csv�����ݱ�����ɽ�ɫ������վλ 
    public void LevelGenerate(string levelName)
    {
        var csvreader = new CSVreader();
        Dictionary<string, int> charaInfo = csvreader.ReadLevel(levelName);
        ScenesMgr.Instance().LoadScean(levelName, () => 
        {
            foreach (KeyValuePair<string, int> entry in charaInfo)
            {
                //ʹ�ü��ؽ�ɫ�ķ��������ɫվλ

            }

        
        });


    }



}

public class CSVreader
{
    public string fileName;

    //��ȡcsv�ؿ���Ϣ������ʵ䱸��
    public Dictionary<string,int> ReadLevel(string fileName)
    {    
        string path = "CSV/Level/" + fileName;
        TextAsset csvFile = ResMgr.Instance().Load<TextAsset>(path);
        Dictionary<string,int> CharaInfo = new Dictionary<string,int>();

        if (csvFile == null ) 
        {
            Debug.LogError($"CSV �ļ�δ�ҵ�: {fileName}.csv");
            return null;
        }

        StringReader reader = new StringReader(csvFile.text);
        bool isFirstLine = true;

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); //ÿ�ζ�ȡ�����л�����һ��
            string[] values = line.Split(',');

            if (isFirstLine) // ����������
            {
                isFirstLine = false;
                continue;
            }

            if (values.Length >= 2) // ������ ��ɫ �� λ��
            {
                string characterName = values[0].Trim(); // ��ɫ��
                int position; // ��������

                if (int.TryParse(values[1].Trim(), out position))
                {
                    CharaInfo[characterName] = position;
                }
                else
                {
                    Debug.LogError($"�޷����� {characterName} ��λ������: {values[1]}");
                }

            }
        }

        return CharaInfo;
    }
}
