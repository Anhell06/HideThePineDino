using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFactory : MonoBehaviour
{
    private Dino dino;
    private Iplace place;
    private ListTransformLevelSO loadSytem;
    private Transform prefPlace;
    private ButtonPushed buttonPushed;
    private IndicatorUpdater indicatorUpdater;
    private Transform[] transforms = new Transform[3];
    private Indicator[] indicators = new Indicator[3];
    private int money, helth, stress;
    private Button nextScen, exit;

    private void Start()
    {
        dino = new Dino();
        dino.LoadData();
        CreatePlace();
        prefPlace = loadSytem.LoadPlace(dino.CurrentPlace);
        buttonPushed = new ButtonPushed(place, prefPlace.GetComponents<Button>());
        dino.GetData(out money, out helth, out stress);
        prefPlace.GetComponents<Indicator>();
        indicators = prefPlace.GetComponents<Indicator>();
        for (int i = 0; i < indicators.Length; i++)
        {
            transforms[i] = indicators[i].transform;
        }
        indicatorUpdater = new IndicatorUpdater(money, helth, stress, transforms);
        buttonPushed.buttonDown += UpdateData;
        nextScen.onClick.AddListener(LoadNextPlace);
        exit.onClick.AddListener(Exit);
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
    private void OnDestroy()
    {
        dino.SaveData();
        buttonPushed.buttonDown -= UpdateData;
    }

}
