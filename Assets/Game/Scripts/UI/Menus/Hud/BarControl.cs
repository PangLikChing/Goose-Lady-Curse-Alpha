using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    public Slider bar;
    public SurvivalStat stat;

    protected virtual void Start()
    {
        bar.maxValue = stat.finalValue;
        bar.value = stat.currentValue;
        bar.minValue = stat.minValue;
    }

    protected virtual void Update()
    {
        if (this.enabled)
        {
            bar.maxValue = stat.finalValue;
            bar.value = stat.currentValue;
            bar.minValue = stat.minValue;
        }
    }

    //public void SetMaxValue(float value)
    //{
    //    bar.maxValue = value;
    //    bar.value = value;
    //}

    //public void SetCurrentValue(float value)
    //{
    //    bar.value = value;
    //}
}
