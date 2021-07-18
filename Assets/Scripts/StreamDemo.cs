using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class StreamDemo : MonoBehaviour
{
    string PlayerName = "Player";
    int age = 123;
    string time = System.DateTime.Now.ToString();
    // Start is called before the first frame update
    void Start()
    {
        
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
        string filePath = Application.persistentDataPath + "/Myfile.file";
        StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(PlayerName);
        sw.WriteLine(age);
        sw.WriteLine(time);
        sw.Close();
    }
    void GetPlayerData()
    {
        string filePath = Application.persistentDataPath + "/Myfile.file";
        StreamReader sr = new StreamReader(filePath);
        string line = sr.ReadLine();
        print(line);
        sr.Close();
    }
}
