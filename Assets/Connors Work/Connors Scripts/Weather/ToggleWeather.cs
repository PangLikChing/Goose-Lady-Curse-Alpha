using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWeather : MonoBehaviour
{
   public GameObject NormalLight;
   public GameObject BasicDayNightCycle;
   public GameObject AdvancedDayNightCycle;
   public GameObject Snow;
   public GameObject Rain;

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



    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
