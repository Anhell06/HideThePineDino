using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFactory : MonoBehaviour
{
    [SerializeField]
    private ListTransformLevelSO loadSytem;
    [SerializeField]
    private Button nextScen, exit;
    [SerializeField]
    private GameObject speechSprite;


    private Dino dino;
    private Iplace place;
    private Transform prefPlace;
    private ButtonPushed buttonPushed;
    private IndicatorUpdater indicatorUpdater;
    private Transform[] transforms = new Transform[3];
    private Indicator[] indicators = new Indicator[3];
    private int money, helth, stress;
    private Result tempResult;
    private Button[] buttons;
    private SpeechResolver speechResolver;

    private void Start()
    {
        dino = new Dino();
        dino.LoadData();
        CreatePlace();
        prefPlace = loadSytem.LoadPlace(dino.CurrentPlace);
        buttons = FindObjectsOfType<Button>();
        buttonPushed = new ButtonPushed(place, buttons);
        dino.GetData(out money, out helth, out stress);
        indicators = FindObjectsOfType<Indicator>();
        for (int i = 0; i < indicators.Length; i++)
        {
            transforms[i] = indicators[i].transform;
        }
        indicatorUpdater = new IndicatorUpdater(money, helth, stress, transforms);
        speechResolver = new SpeechResolver(buttonPushed, indicatorUpdater, speechSprite);
        buttonPushed.buttonDown += UpdateData;
        //nextScen.onClick.AddListener(LoadNextPlace);
        //exit.onClick.AddListener(Exit);
        // animatorResolver = new AnimatorResolver();
    }

    private void UpdateData(Result result)
    {
        speechResolver.SaySpeech(result);
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
