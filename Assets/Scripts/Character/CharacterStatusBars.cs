using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusBars : MonoBehaviour
{
    public enum BarType
    {
        HealthBar,
        ProcessBar
    }


    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider processBar;

    public void AddValue(BarType type, int currentValue, int maxValue)
    {
        switch (type)
        {
            case BarType.HealthBar: AddValueSlider(ref healthBar, currentValue, maxValue); break;
            case BarType.ProcessBar: AddValueSlider(ref processBar, currentValue, maxValue); break;
        }
    }

    private void AddValueSlider(ref Slider slider, int currentValue, int maxValue)
    {
        slider.value = currentValue;
        slider.maxValue = maxValue;
    }
}