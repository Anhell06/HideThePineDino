using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechResolver 
{
    private readonly ButtonPushed buttonPushed;
    private readonly IndicatorUpdater indicatorUpdater;
    private GameObject speechSprite;
    private Result result;
    private Animation aimator;
    private CatalogAnimation catalogAnimation;
    public SpeechResolver(ButtonPushed buttonPushed, IndicatorUpdater indicatorUpdater, GameObject speechSprite)
    {
        this.buttonPushed = buttonPushed;
        this.indicatorUpdater = indicatorUpdater;
        this.speechSprite = speechSprite;
        catalogAnimation = Resources.Load<CatalogAnimation>("ScriptableObject/CatalogForAnimation");

    }

    public void SaySpeech(Result result)
    {
        this.result = result;
        PlaySpech();
    }

    private IEnumerable PlaySpech()
    {

        buttonPushed.ButtonActive(false);
        PlayAnimation(result.typeAnimation);
        yield return null;

        buttonPushed.ButtonActive(true);
        indicatorUpdater.UpdateIndicator(result);
        yield break;

    }

    private void PlayAnimation(animationType type)
    {
        var anim = catalogAnimation.GetAnimation(type);
        aimator = anim.animator;
        aimator.Play(anim.name);

    }
    public void AnimationEnded()
    {
        PlaySpech();
    }
    




}
