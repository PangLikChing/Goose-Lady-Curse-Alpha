using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureBar : BarControl
{
    public float maxTemperature;
    public float minTemperature;
    // Start is called before the first frame update
    protected override void Start()
    {
        bar.maxValue = maxTemperature;
        bar.value = stat.currentValue;
        bar.minValue = minTemperature;
    }

    // Update is called once per frame
    protected override void Update()
    {
        bar.value = stat.currentValue;
    }
}
