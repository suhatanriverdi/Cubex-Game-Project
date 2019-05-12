using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
  public static void SavePlayer(GameController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/cubeX.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData DataLoader()
    {
        string path = Application.persistentDataPath + "/cubeX.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
           // Debug.LogError("file does not found");
            return null;
        }
    }
    public static void Reset()
    {
        string path = Application.persistentDataPath + "/cubeX.bin";
        File.Delete(path);
    }
}
