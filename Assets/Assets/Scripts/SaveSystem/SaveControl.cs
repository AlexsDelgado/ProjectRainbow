using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveControl
{
    private static string SavePath => Application.persistentDataPath + "/savefile.dat";

    public static void SavePlayerData(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(SavePath, FileMode.Create))
        {
            formatter.Serialize(stream, playerData);
        }
        Debug.Log("Saved data in: " + SavePath);
    }
    public static PlayerData LoadPlayerData()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("Data doesn't exist...");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(SavePath, FileMode.Open))
        {
            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            Debug.Log("Loaded data from: " + SavePath);
            return playerData;
        }
    }
    public static bool DataExists()
    {
        return File.Exists(SavePath);
    }
    public static void DeletePlayerData()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
            Debug.Log("Data deleted");
        }
    }
}
