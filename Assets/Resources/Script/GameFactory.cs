using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFactory : MonoBehaviour
{
    [SerializeField]
    private ListTransformLevelSO loadSytem;


    private Dino dino;
    private Iplace place;
    private Transform prefPlace;
    private ButtonPushed buttonPushed;
    private IndicatorUpdater indicatorUpdater;
    private Transform[] transforms = new Transform[3];
    private Indicator[] indicators = new Indicator[3];
    private int money, helth, stress;
    private Result tempResult;
    private Button nextScen, exit;
    private AnimatorResolver animatorResolver;

    private void Start()
    {
        dino = new Dino();
        dino.LoadData();
        CreatePlace();
        prefPlace = loadSytem.LoadPlace(dino.CurrentPlace);
        buttonPushed = new ButtonPushed(place, FindObjectsOfType<Button>());
        dino.GetData(out money, out helth, out stress);
        prefPlace.GetComponents<Indicator>();
        indicators = FindObjectsOfType<Indicator>();
        for (int i = 0; i < indicators.Length; i++)
        {
            transforms[i] = indicators[i].transform;
        }
        indicatorUpdater = new IndicatorUpdater(money, helth, stress, transforms);
        buttonPushed.buttonDown += UpdateData;
        nextScen.onClick.AddListener(LoadNextPlace);
        exit.onClick.AddListener(Exit);
       // animatorResolver = new AnimatorResolver();
    }

    private void UpdateData(Result result)
    {
        indicatorUpdater.UpdateIndicator(tempResult);
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
    private void OnDestroy()
    {
        dino.SaveData();
        buttonPushed.buttonDown -= UpdateData;
    }

}