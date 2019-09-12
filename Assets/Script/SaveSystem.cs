using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public class SaveData 
{
    public string Name;
    public List<string> Inventory;
   
    public Transform LastPosition;

    public SaveData(SaveData save)
    {
        Name = save.Name;
        Inventory = save.Inventory;
        LastPosition = save.LastPosition;
    }
    public SaveData()
    {
        Name = "None";
        Inventory = new List<string>();
    }

}
public static class SaveSystem 
{
    public static void SaveGame (SaveData save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Savedata.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(save);

        formatter.Serialize(stream,data);
        stream.Close();

    }
     public static SaveData LoadSaveGame()
    {
        string path = Application.persistentDataPath + "/Savedata.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Don't Have File Save Game !!!! ");
            return new SaveData();
        }
    }
}
