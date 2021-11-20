using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonPushed
{
    private readonly Iplace place;
    private readonly Button[] buttons;
    public Action<Result, string> buttonDown;
    public TMP_Text[] textButton = new TMP_Text[3];
    public string[] texts;

    public ButtonPushed(Iplace place, Button[] buttons)
    {

        this.place = place;
        this.buttons = buttons;

        for (int i = 0; i < buttons.Length; i++)
        {
            textButton[i] = buttons[i].GetComponentInChildren<TMP_Text>();
        }
        UpdateButton();

        buttons[0].onClick.AddListener(() => Push(0));
        buttons[1].onClick.AddListener(() => Push(1));
        buttons[2].onClick.AddListener(() => Push(2));

    }
    public void Push(int numberButton)
    {
        buttonDown?.Invoke(place.ResultRelaxing(numberButton), texts[numberButton]);
        UpdateButton();
    }

    private void UpdateButton()
    {
        texts = place.GetTextForButton();
        for (int i = 0; i < buttons.Length; i++)
        {

            if (texts[i].Length > 36)
            {
                textButton[i].text = texts[i].Substring(0, 35) + "...";

            }
            else
            {
                textButton[i].text = texts[i];
            }
            
        }
    }

    public void ButtonActive(bool active)
    {
        foreach (var button in buttons)
        {
            button.transform.gameObject.SetActive(active);
        }
    }

}