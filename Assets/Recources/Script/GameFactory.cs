using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFactory : MonoBehaviour
{
    private Dino dino;
    private Iplace place;
    private LoadSystemSO loadSytem;
    private Transform prefPlace;
    private ButtonPushed buttonPushed;
    private IndicatorUpdater indicatorUpdater;

    private void Start()
    {
        dino = new Dino();
        dino.LoadData();
        CreatePlace();
        prefPlace = loadSytem.LoadPlace(dino.CurrentPlace);
        buttonPushed = new ButtonPushed(place, prefPlace.GetComponents<Button>());
        indicatorUpdater = new IndicatorUpdater(prefPlace.GetComponents<Indicator>());
        buttonPushed.buttonDown += UpdateData;
    }

    private void UpdateData(Result result)
    {
        indicatorUpdater.UpdateIndicator(result);
    }

    private void LoadNextPlace()
    {
        switch (dino.CurrentPlace)
        {
            case Place.Bar:
                dino.CurrentPlace = Place.Home;
                break;
            case Place.Home:
                dino.CurrentPlace = Place.Bar;
                break;
            default:
                break;
        }
        dino.SaveData();
        SceneManager.LoadScene(1);

    }
    private void Exit()
    {
        SceneManager.LoadScene(0);
    }
    private void CreatePlace()
    {
        switch (dino.CurrentPlace)
        {
            case Place.Bar:
                place = new Bar();
                break;
            case Place.Home:
                place = new Home();
                break;
            default:
                break;
        }
    }

}
