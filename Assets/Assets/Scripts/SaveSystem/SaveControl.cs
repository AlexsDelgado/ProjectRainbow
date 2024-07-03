using UnityEngine;
using System.IO;

public static class SaveControl
{
    private static string SavePath => Application.persistentDataPath + "/savefile.json";

    public static void SavePlayerData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("Saved data in: " + SavePath);
    }

    public static PlayerData LoadPlayerData()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("Data doesnt exist... Loading deault values");
            return null;
        }

        string json = File.ReadAllText(SavePath);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("Loaded data from: " + SavePath);
        return playerData;
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
