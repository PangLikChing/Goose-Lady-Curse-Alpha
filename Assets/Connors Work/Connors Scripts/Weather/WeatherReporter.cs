using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherReporter : MonoBehaviour
{
    //variable declaration
    public GameObject AdvancedDayNightCycle;
    public GameObject SimpleDayNightCycle;
    public GameObject Snow;
    public GameObject Rain;
    public bool IsSnowing;
    public bool IsRaining;

    //checks the weather to see if its snowing
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

    //checks the weather to see if its raining
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

    //returns an instncae of the simple day night cycle
    public string GetSimpleDayNightCycle()
    {
        string result = SimpleDayNightCycle.GetComponent<ReworkedLightingManager>().GetSimpleCycle();
        return result;
    }

    //retruns an instance of the advanced day nighr cycle 
    public string GetAdvancedDayNightCycle()
    {
        string result = AdvancedDayNightCycle.GetComponent<OriginalLightingManager>().GetAdvancedCycle();
        return result;
    }
}