using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherReporter : MonoBehaviour
{
    public GameObject AdvancedDayNightCycle;
    public GameObject SimpleDayNightCycle;
    public GameObject Snow;
    public GameObject Rain;
    public bool IsSnowing;
    public bool IsRaining;

    public bool GetIsSnowing()
    {
        if(Snow.active == true)
        {
            IsSnowing = true;
            return IsSnowing;
        }
        else
        {
            IsSnowing = false;
            return IsSnowing;
        }
    }

    public bool GetIsRaining()
    {
        if (Rain.active == true)
        {
            IsRaining = true;
            return IsRaining;
        }
        else
        {
            IsRaining = false;
            return IsRaining;
        }
    }

    public string GetSimpleDayNightCycle()
    {
        string result = SimpleDayNightCycle.GetComponent<ReworkedLightingManager>().GetSimpleCycle();
        return result;
    }

    public string GetAdvancedDayNightCycle()
    {
        string result = AdvancedDayNightCycle.GetComponent<OriginalLightingManager>().GetAdvancedCycle();
        return result;
    }
}