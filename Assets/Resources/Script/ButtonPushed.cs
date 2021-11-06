using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonPushed
{
    private readonly Iplace place;
    private readonly Button[] buttons;
    public Action<Result> buttonDown;
    public TMP_Text[] textButton = new TMP_Text[3];

    public ButtonPushed(Iplace place, Button[] buttons) 
    {
        
        this.place = place;
        this.buttons = buttons;

        Debug.Log(buttons.Length);
        for (int i = 0; i < buttons.Length; i++)
        {

            textButton[i] = buttons[i].GetComponentInChildren<TMP_Text>();
        }
        UpdateButton();
    }
    public void Push(int numberButton)
    {
        buttonDown?.Invoke(place.ResultRelaxing(numberButton));
        UpdateButton();
    }

    private void UpdateButton()
    {
        string[] texts = place.GetTextForButton();
        for (int i = 0; i < buttons.Length ; i++)
        {

            textButton[i].text = texts[i];
        }
    }

}