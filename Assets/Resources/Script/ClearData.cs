using System;
using UnityEngine;

[Serializable]
public static class ClearData
{
    public static void Clear()
    {
        PlayerPrefs.SetInt(SaveKey.money.ToString(), 0);
        PlayerPrefs.SetInt(SaveKey.helth.ToString(), 70);
        PlayerPrefs.SetInt(SaveKey.stress.ToString(), 30);
        PlayerPrefs.SetInt(SaveKey.currentPlace.ToString(), (int) Place.Bar);
    }
}
