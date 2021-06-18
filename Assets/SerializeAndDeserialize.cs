using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Windows;


public class SerializeAndDeserialize : MonoBehaviour
{
    string PlayerName = "Player";
    int age = 123;
    //string time = System.DateTime.Now.ToString();
    float time = 10.5f;

    string systemName = Environment.MachineName.ToString();

    string systemResolutionWidth;

    int memory;

    //float systemResolutionHeight = (float)SystemParameters.FullPrimaryScreenHeight;
    void Start()
    {
         systemResolutionWidth = Screen.currentResolution.ToString();
         memory = SystemInfo.systemMemorySize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetPlayerData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }
    void SetPlayerData()
    {
        string filePath = UnityEngine.Application.persistentDataPath + "/Myfile.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter sw = new BinaryWriter(fs);
        sw.Write(systemName);
        sw.Write((string)systemResolutionWidth);
        sw.Write(memory);
        //sw.Write((double)systemResolutionHeight);
        fs.Close();
        sw.Close();
    }
    void GetPlayerData()
    {
        string filePath = Application.persistentDataPath + "/Myfile.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryReader sw = new BinaryReader(fs);
        systemName = sw.ReadString();
        //age = sw.ReadInt32();
        ///time = ((float)sw.ReadDouble());
        Debug.Log("SystemName: " + systemName + " " + "Width&Height " + systemResolutionWidth + " " + "System Memory: " + memory);
        systemResolutionWidth = ((string)sw.ReadString());
        memory = (sw.ReadInt32());
        //systemResolutionHeight = ((float)sw.ReadDouble());
        fs.Close();
        sw.Close();
    }
}
