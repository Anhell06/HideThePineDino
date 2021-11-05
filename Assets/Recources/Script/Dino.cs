using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino
{
    private int money;
    private int helth;
    private int stress;
    private int currentPlace;
    public Iplace SetCurrentPlace
    {
        get => currentPlace;
        set => currentPlace = (int) Place.Bar;
    }

    public void GetData(out int money, out int helth, out int stress)
    {
        money = this.money;
        helth = this.helth;
        stress = this.stress;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(SaveKey.money.ToString(), money);
        PlayerPrefs.SetInt(SaveKey.helth.ToString(), helth);
        PlayerPrefs.SetInt(SaveKey.stress.ToString(), stress);
        PlayerPrefs.SetInt(SaveKey.currentPlace.ToString(), currentPlace);
    }

    public void LoadData()
    {
        money = PlayerPrefs.GetInt(SaveKey.money.ToString(), 0);
        helth =PlayerPrefs.GetInt(SaveKey.helth.ToString(), 70);
        stress = PlayerPrefs.GetInt(SaveKey.stress.ToString(), 30);
        currentPlace = PlayerPrefs.GetInt(SaveKey.currentPlace.ToString());
    }

}

enum SaveKey
{
    money,
    helth,
    stress,
    currentPlace
}
enum Place
{ 
    Bar,
    Home
}

