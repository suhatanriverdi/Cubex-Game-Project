using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

// Büşra Nur BAHADIR 201511006
public static class SaveSystem
{

    //save player data as Hashtable
  public static void SavePlayer(Hashtable player)
    {
        BinaryFormatter formatter = new BinaryFormatter();  //create binary formatter

        //This value is a directory path where you can store data that you want to be kept between runs.
        //When you publish on iOS and Android, persistentDataPath points to a public directory on the device.
        string path = Application.persistentDataPath+ "/cubeX.bin"; 

        FileStream stream = new FileStream(path, FileMode.Create); //create file on the path 
        Hashtable data = new Hashtable(player);
        formatter.Serialize(stream, player);
        stream.Close();
    }

    //load data from file
    public static Hashtable DataLoader()
    {
        string path = Application.persistentDataPath + "/cubeX.bin"; //path of the file

        //if file is exists on the  path open it 
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Hashtable data = formatter.Deserialize(stream) as Hashtable;
            stream.Close();
            return data;
        }
        else
        {
           // Debug.LogError("file does not found");
            return null;
        }
    }

    //delete file 
    public static void Reset()
    {
        string path = Application.persistentDataPath + "/cubeX.bin";
        File.Delete(path);
    }
}
