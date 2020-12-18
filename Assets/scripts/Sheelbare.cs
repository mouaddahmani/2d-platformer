using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheelbare : MonoBehaviour
{
    public Slider slider;

    public void setMaxSheeld(float Sheeld)
    {
        slider.maxValue = Sheeld;
        slider.value = Sheeld;
    }

    public void setSheeld(float Sheeld)
    {
        slider.value = Sheeld;
    }
}
