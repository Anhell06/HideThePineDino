using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class IndicatorUpdater
{
    private readonly Transform[] indicators;

    private Slider indicatorMoney;
    private Slider indicatorHealth;
    private Slider indicatorStress;
    public Action<bool> EndGame;

    public IndicatorUpdater(int money, int health, int stress, Transform[] indicators)
    {
        type privatType;

        foreach (var i in indicators)
        {
            this.indicators = indicators;

            privatType = i.GetComponent<Indicator>().Type;

            switch (privatType)
            {
                case type.money:
                    indicatorMoney = i.GetComponent<Slider>();
                    break;
                case type.health:
                    indicatorHealth = i.GetComponent<Slider>();
                    break;
                case type.stress:
                    indicatorStress = i.GetComponent<Slider>();
                    break;
            }
        }
        indicatorMoney.maxValue = 100;
        indicatorMoney.minValue = 0;
        indicatorMoney.value = money;

        indicatorHealth.maxValue = 100;
        indicatorHealth.minValue = 0;
        indicatorHealth.value = health;

        indicatorStress.maxValue = 100;
        indicatorStress.minValue = 0;
        indicatorStress.value = stress;
    }

    public void UpdateIndicator(Result result)
    {
        SetValue(indicatorMoney, result.changeMoney);
        SetValue(indicatorHealth, result.changeHelth);
        SetValue(indicatorStress, result.changeStress);
        if (indicatorStress.value == 100 )
        {
            PlayerPrefs.SetString("Артур впал в непрекращающуюся депрессию", "lose");
            EndGame?.Invoke(false);
        }
        if (indicatorHealth.value == 0)
        {

            PlayerPrefs.SetString("У вас больше нет сил играть на сцене", "lose");
            EndGame?.Invoke(false);
        }
        if (indicatorMoney.value == 0)
        {

            PlayerPrefs.SetString("У вас больше не на что жить", "lose");
            EndGame?.Invoke(false);
        }
        if (indicatorMoney.value == 100)
        {
            EndGame?.Invoke(true);
        }
        Debug.LogError(indicatorStress.value);
        
    }

    private void SetValue(Slider slider, int value)
    {
        Debug.Log(value);
        value += (int)slider.value;

        if (value > 100)
        {
            value = 100;
        }

        if (value < 0)
        {
            value = 0;
        }
        slider.value = value;
    }
}
