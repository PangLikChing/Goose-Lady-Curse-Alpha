using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public Stat coldProtection;
    public SurvivalStat temperatureStat;
    [Header("Forest")]
    public Modifier forestDay;
    public float forestDayMinimalTemperature;
    private Modifier forestNight;
    private float forestNightMinimalTemperature;
    public Modifier forestRainyDay;
    public float forestRainyDayMinimalTemperature;
    private Modifier forestRainyNight;
    private float forestRainyNightMinimalTemperature;
    [Header("Beach")]
    public Modifier beachDay;
    public float beachDayMinimalTemperature;
    private Modifier beachNight;
    private float beachNightMinimalTemperature;
    
    private Modifier mountainDay;
    private float mountainDayMinimalTemperature;
    private Modifier mountainNight;
    private float mountainNightMinimalTemperature;
    [Header("Mountain")]
    public Modifier mountainSnowyDay;
    public float mountainSnowyDayMinimalTemperature;
    private Modifier mountainSnowyNight;
    private float mountainSnowyNightMinimalTemperature;

    private Modifier currentModifier;


    public void Initialize()
    {
        currentModifier = null;
        ApplyForestDay();//need to vary depending on the respawn locations
    }

    private void Update()
    {
        //temperatureStat.actualChangeRate += coldProtection.finalValue;
    }

    public void ApplyForestDay()
    {
        ApplyDecreasingModifier(forestDay, forestDayMinimalTemperature);
    }

    private void ApplyForestNight()
    {

        ApplyDecreasingModifier(forestNight,forestNightMinimalTemperature);
    }

    public void ApplyForestRainyDay()
    {
        ApplyDecreasingModifier(forestRainyDay,forestRainyDayMinimalTemperature);
    }

    private void ApplyForestRainyNight()
    {
        ApplyDecreasingModifier(forestRainyNight,forestRainyNightMinimalTemperature);
    }

    public void ApplyBeachDay()
    {
        Debug.Log("BE");
        ApplyDecreasingModifier(beachDay, beachDayMinimalTemperature);
    }

    private void ApplyBeachNight()
    {
        ApplyDecreasingModifier(beachNight,beachNightMinimalTemperature);
    }

    private void ApplyMountainDay()
    {
        ApplyDecreasingModifier(mountainDay,mountainDayMinimalTemperature);
    }

    private void ApplyMountainNight()
    {
        ApplyDecreasingModifier(mountainNight,mountainNightMinimalTemperature);
    }

    public void ApplyMountainSnowyDay()
    {
        ApplyDecreasingModifier(mountainSnowyDay,mountainSnowyDayMinimalTemperature);
    }

    private void ApplyMountainSnowyNight()
    {
        ApplyDecreasingModifier(mountainSnowyNight,mountainSnowyNightMinimalTemperature);
    }

    private void ApplyDecreasingModifier(Modifier modifier, float minTemperature)
    {
        if (currentModifier != null)
        {
            currentModifier.Remove();
        }
        modifier.Apply();
        currentModifier = modifier;
        temperatureStat.minValue = minTemperature;
    }

    private void ApplyIncreasingModifier(Modifier modifier, float maxTemperature)
    {
        if (currentModifier != null)
        {
            currentModifier.Remove();
        }
        modifier.Apply();
        currentModifier = modifier;
        temperatureStat.baseValue = maxTemperature;
    }
}
