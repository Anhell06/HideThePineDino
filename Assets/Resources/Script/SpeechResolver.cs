using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechResolver
{
    private readonly ButtonPushed buttonPushed;
    private readonly IndicatorUpdater indicatorUpdater;
    private GameObject speechSprite;
    private Result result;
    private GameObject aimator;
    private CatalogAnimation catalogAnimation;
    private bool firstPlaySpeech = true;
    public  Action<GameObject> startAnimation;
    public GameObject anim;
    public SpeechResolver(ButtonPushed buttonPushed, IndicatorUpdater indicatorUpdater)
    {
        this.buttonPushed = buttonPushed;
        this.indicatorUpdater = indicatorUpdater;
        catalogAnimation = Resources.Load<CatalogAnimation>("ScriptableObject/CatalogForAnimation");

    }

    public void SaySpeech(Result result)
    {
        this.result = result;
        Debug.Log("rfvtgb");
        PlaySpech();
    }

    private void PlaySpech()
    {
        Debug.Log("asdafs");
        if (firstPlaySpeech)
        {
            buttonPushed.ButtonActive(false);
            PlayAnimation(result.typeAnimation);
            firstPlaySpeech = false;
        }
        else
        {
            buttonPushed.ButtonActive(true);
            indicatorUpdater.UpdateIndicator(result);

            firstPlaySpeech = true;
        }


    }

    private void PlayAnimation(animationType type)
    {
        anim = catalogAnimation.GetAnimation(type).animator;
        Debug.Log(anim);
       
        anim.SetActive(true);
        startAnimation?.Invoke(anim);



    }
    public void AnimationEnded()
    {
        PlaySpech();
    }





}
