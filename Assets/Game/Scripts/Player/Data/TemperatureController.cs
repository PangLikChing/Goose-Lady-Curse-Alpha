using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureController : MonoBehaviour
{
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

    private void Start()
    {
        
    }

    public void ApplyForestDay()
    {
        ApplyDecreasingModifier(forestDay, forestDayMinimalTemperature);
    }

    public void ApplyForestNight()
    {

        ApplyDecreasingModifier(forestNight,forestNightMinimalTemperature);
    }

    public void ApplyForestRainyDay()
    {
        ApplyDecreasingModifier(forestRainyDay,forestRainyDayMinimalTemperature);
    }

    public void ApplyForestRainyNight()
    {
        ApplyDecreasingModifier(forestRainyNight,forestRainyNightMinimalTemperature);
    }

    public void ApplyBeachDay()
    {
        ApplyDecreasingModifier(beachDay, beachDayMinimalTemperature);
    }

    public void ApplyBeachNight()
    {
        ApplyDecreasingModifier(beachNight,beachNightMinimalTemperature);
    }

    public void ApplyMountainDay()
    {
        ApplyDecreasingModifier(mountainDay,mountainDayMinimalTemperature);
    }

    public void ApplyMountainNight()
    {
        ApplyDecreasingModifier(mountainNight,mountainNightMinimalTemperature);
    }

    public void ApplyMountainSnowyDay()
    {
        ApplyDecreasingModifier(mountainSnowyDay,mountainSnowyDayMinimalTemperature);
    }

    public void ApplyMountainSnowyNight()
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
