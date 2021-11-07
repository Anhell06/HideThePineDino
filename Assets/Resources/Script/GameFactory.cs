using System;
using System.Collections;
using TMPro;
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
    [SerializeField]
    private TMP_Text SpeechPlace;


    private Dino dino;
    private Iplace place;
    private Transform prefPlace;
    private ButtonPushed buttonPushed;
    private IndicatorUpdater indicatorUpdater;
    private Transform[] transforms = new Transform[3];
    private Indicator[] indicators = new Indicator[3];
    private int money, helth, stress;
    private Result tempResult;
    private Button[] buttons = new Button[3];
    private SpeechResolver speechResolver;

    private void Start()
    {
        dino = new Dino();
        dino.LoadData();
        CreatePlace();
        prefPlace = loadSytem.LoadPlace(dino.CurrentPlace);
        var buttonForUse = FindObjectsOfType<ButtonForUse>();
        Debug.Log(buttonForUse.GetType());
        for (int i = 0; i < buttonForUse.Length; i++)
        {
            Debug.Log(i);
            buttons[i] = buttonForUse[i].GetComponent<Button>();
        }
        buttonPushed = new ButtonPushed(place, buttons);
        dino.GetData(out money, out helth, out stress);
        indicators = FindObjectsOfType<Indicator>();
        for (int i = 0; i < indicators.Length; i++)
        {
            transforms[i] = indicators[i].transform;
        }
        indicatorUpdater = new IndicatorUpdater(money, helth, stress, transforms);
        speechResolver = new SpeechResolver(buttonPushed, indicatorUpdater);
        buttonPushed.buttonDown += UpdateData;
        speechResolver.startAnimation += WaitFiveSeond;
        //nextScen.onClick.AddListener(LoadNextPlace);
        //exit.onClick.AddListener(Exit);
        // animatorResolver = new AnimatorResolver();
    }

    private IEnumerator WaitAnim(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        SpeechPlace.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        speechResolver.AnimationEnded();
        Destroy(obj);

    }
    private void WaitFiveSeond(GameObject obj)
    {
        var dest = Instantiate(obj);
        
        StartCoroutine("WaitAnim", dest);
        
    }

    private void UpdateData(Result result, string text)
    {
        speechResolver.SaySpeech(result);
        SpeechPlace.gameObject.SetActive(true);
        SpeechPlace.text = text;
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
