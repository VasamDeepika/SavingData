using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization;
using System;

public class NestedClassesDemo : MonoBehaviour
{
    string playerName = "Deepika";
    int playerAge = 21;
    int playerScore = 100;
    string playerLocation = "Andhra";
    [System.Serializable]
    private class DataDemo
    {
        public string playerName;
        public int playerAge;
        public int playerScore;
        public DataDemo(string playerName, int playerAge, int playerScore)
        {
            this.playerName = playerName;
            this.playerAge = playerAge;
            this.playerScore = playerScore;
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
        DataDemo dm = new DataDemo(playerName, playerAge, playerScore);
        bw.Serialize(fs, dm);
        fs.Close();
    }
    void GetPlayerData()
    {
        string filepath = Application.persistentDataPath + "/NestedDemo.file";

        BinaryFormatter bwr = new BinaryFormatter();
        FileStream fsm = new FileStream(filepath, FileMode.OpenOrCreate);
        DataDemo data = bwr.Deserialize(fsm) as DataDemo;
        string name = data.playerName;
        int age = data.playerAge;
        int score = data.playerScore;

        Debug.Log(("Player: " + name + " " + "Age: " + age + " " + "Score: " + score));


        //string test = data[playername] as string;

        fsm.Close();


    }
}