using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWeather : MonoBehaviour
{
    //variable declaration
   public GameObject NormalLight;
   public GameObject BasicDayNightCycle;
   public GameObject AdvancedDayNightCycle;
   public GameObject Snow;
   public GameObject Rain;

    //toggles the basic day night cycle between on and off
    public void ToggleBasicDayNightCycle()
    {
        if(BasicDayNightCycle.active == false)
        {
            NormalLight.SetActive(false);
            BasicDayNightCycle.SetActive(true);
        }
        else
        {
            NormalLight.SetActive(true);
            BasicDayNightCycle.SetActive(false);
        }
    }

    //toggles the advanced day night cycle between on and off
    public void ToggleAdvancedDayNightCycle()
    {
        if (AdvancedDayNightCycle.active == false)
        {
            NormalLight.SetActive(false);
            AdvancedDayNightCycle.SetActive(true);
        }
        else
        {
            NormalLight.SetActive(true);
            AdvancedDayNightCycle.SetActive(false);
        }
    }

    //toggles the rain between on and off
    public void ToggleRain()
    {
        if (Rain.active == false)
        {
            Rain.SetActive(true);
        }
        else
        {
            Rain.SetActive(false);
        }
    }

    //toggles the snow between on and off
    public void ToggleSnow()
    {
        if (Snow.active == false)
        {
            Snow.SetActive(true);
        }
        else
        {
            Snow.SetActive(false);
        }
    }
}
