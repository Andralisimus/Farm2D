using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataBase 
{
    private static string inventoryPath = Application.persistentDataPath + "/inventory.path";
    private static string playerDataPath = Application.persistentDataPath + "/playerData.path";
    private static string cropsDataPath = Application.persistentDataPath + "/crops.path";
    private static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void Save()
    {
        SaveInventory();
        SavePlayerData();
    }

    public static void SaveCrops(List<Item> crops)
    {
        FileStream stream = new FileStream(cropsDataPath, FileMode.Create);
        binaryFormatter.Serialize(stream, crops);
        stream.Close();
    }

    public static List<Item> LoadCrops()
    {
        if (File.Exists(cropsDataPath))
        {
            FileStream stream = new FileStream(cropsDataPath, FileMode.Open);

            List<Item> items = (List<Item>)binaryFormatter.Deserialize(stream);
            stream.Close();

            return items;
        }
        else
        {
            List<Item> startCrops = new List<Item>();

            startCrops.Add(Player.getEmptyItem());
            startCrops.Add(Player.getEmptyItem());
            startCrops.Add(Player.getEmptyItem());
            startCrops.Add(Player.getEmptyItem());

            return startCrops;
        }
    }

    public static void SaveInventory()
    {
        FileStream stream = new FileStream(inventoryPath, FileMode.Create);
        binaryFormatter.Serialize(stream, Player.items);
        stream.Close();
    }

    public static List<Item> LoadInventory()
    {
        if (File.Exists(inventoryPath)) {
            FileStream stream = new FileStream(inventoryPath, FileMode.Open);
            
            List<Item> items = (List<Item>)binaryFormatter.Deserialize(stream);
            stream.Close();

            return items;
        } else
        {
            List<Item> startItems = new List<Item>();

            startItems.Add(Player.getEmptyItem());
            startItems.Add(new Item("plow", "Tools/Plow", 0, Item.TYPEPLOW, 0, 0, 0f));
            startItems.Add(Player.getEmptyItem());
            startItems.Add(Player.getEmptyItem());
            startItems.Add(Player.getEmptyItem());
            startItems.Add(Player.getEmptyItem());
            startItems.Add(Player.getEmptyItem());

            return startItems;
        }
    }

    public static void SavePlayerData()
    {
        FileStream stream = new FileStream(playerDataPath, FileMode.Create);
        string currentTime = System.DateTime.Now.ToBinary().ToString();
        PlayerData playerData = new PlayerData(Player.money, Player.lvl, Player.lvlProgress, currentTime);
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(playerDataPath))
        {
            FileStream stream = new FileStream(playerDataPath, FileMode.Open);

            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(stream);
            stream.Close();

            playerData.timeOffline = GetOfflineTime(playerData.lastSavedTime);

            return playerData;
        } else return new PlayerData(200, 4, 0, "");
    }
    public static void ClearDataBase()
    {
        if (File.Exists(inventoryPath)) { File.Delete(inventoryPath); }
        if (File.Exists(playerDataPath)) { File.Delete(playerDataPath); }
        if (File.Exists(cropsDataPath)) { File.Delete(cropsDataPath); }
    }

    private static long GetOfflineTime(string lastSavedTime)
    {
        var currentTime = System.DateTime.Now;
        var lastSavedTimeConverted = System.Convert.ToInt64(lastSavedTime);

        System.DateTime oldTime = System.DateTime.FromBinary(lastSavedTimeConverted);

        System.TimeSpan difference = currentTime.Subtract(oldTime);

        return (long)difference.TotalSeconds;
    }
}
