using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSaveMethod : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
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
        PlayerPrefs.SetInt("Score", 100);
        PlayerPrefs.SetString("Name", "Player");
        PlayerPrefs.SetFloat("Time", 2.1f);
        print("Saved the player Score");
    }

    void GetPlayerData()
    {
        int score = PlayerPrefs.GetInt("Score");
        string name = PlayerPrefs.GetString("Name");
        float time = PlayerPrefs.GetFloat("Time");
        print("The player score is: "+score);
        print("The player name is: " + name);
        print("The player time is: " + time);
    }
}
