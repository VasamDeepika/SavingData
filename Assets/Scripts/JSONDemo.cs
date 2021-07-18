using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;

public class JSONDemo : MonoBehaviour
{
    public string name;
    public int age;
    public string[] friends;
    void Start()
    {

    }
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
        string filePath = Application.persistentDataPath + "/JSONDemo.file";

        JObject jobj = new JObject();
        jobj.Add("componentName",this.name);

        JObject jdataDemo = new JObject();
        jobj.Add("data", jdataDemo);
        jdataDemo.Add("name", "abcd");
        jdataDemo.Add("_curHp", 1001111);

        JArray jarraydata = JArray.FromObject(friends);
        jdataDemo.Add("_friends", jarraydata);

        StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(jobj.ToString());

        sw.Close();
        
    }
    void GetPlayerData()
    {
        string filePath = Application.persistentDataPath + "/JSONDemo.file";
        print(filePath);

        StreamReader sr = new StreamReader(filePath);
        string data = sr.ReadToEnd();
        sr.Close();

        print(data);

        JObject dataDemo = JObject.Parse(data);
        name = dataDemo["componentName"].Value<string>();
        age = dataDemo["data"]["_curHp"].Value<int>();
        friends = dataDemo["data"]["_friends"].ToObject<string[]>();
    }

}
   

