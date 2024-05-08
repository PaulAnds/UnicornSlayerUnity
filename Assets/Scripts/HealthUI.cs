using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.maxValue = 5;
        slider.value = 5;
    }
    public void setmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void sethealth(int health)
    {
        slider.value = health;
    }
}
