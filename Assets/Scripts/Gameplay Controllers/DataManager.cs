using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetData(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
}
