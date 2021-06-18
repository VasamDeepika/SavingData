using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization;
using System;

public class NestedClassesDemo : MonoBehaviour
{
    string playername = "Shirini";
    int playerage = 22;
    int playerscore = 100;
    string playerlocation = "Hyd";
    [System.Serializable]
    private class DataDemo
    {
        public string playername;
        public int playerage;
        public int playerscore;
        public DataDemo(string playername, int playerage, int playerscore)
        {
            this.playername = playername;
            this.playerage = playerage;
            this.playerscore = playerscore;
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }
    void SavePlayerData()
    {
        string filepath = Application.persistentDataPath + "/NestedDemo.file";
        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        BinaryFormatter bw = new BinaryFormatter();
        DataDemo dm = new DataDemo(playername, playerage, playerscore);
        bw.Serialize(fs, dm);
        fs.Close();


    }
    void GetPlayerData()
    {
        string filepath = Application.persistentDataPath + "/NestedDemo.file";

        BinaryFormatter bwr = new BinaryFormatter();
        FileStream fsm = new FileStream(filepath, FileMode.OpenOrCreate);
        DataDemo data = bwr.Deserialize(fsm) as DataDemo;
        string name = data.playername;
        int age = data.playerage;
        int score = data.playerscore;

        Debug.Log(("Player" + name + "age:" + age + "Score:" + score));


        //string test = data[playername] as string;

        fsm.Close();


    }
}