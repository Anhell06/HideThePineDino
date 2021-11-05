using System;
using UnityEngine.UI;

public class ButtonPushed
{
    private readonly Iplace place;
    private readonly Button[] buttons;
    public Action<Result> buttonDown;
    public Text[] textButton;

    public ButtonPushed(Iplace place, Button[] buttons) 
    {
        this.place = place;
        this.buttons = buttons;
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            textButton[i] = buttons[i].GetComponent<Text>();
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
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            textButton[i].text = texts[i];
        }
    }

}