using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SurvivalElement : MonoBehaviour
{
    public Condition condition;
    public Modifier modifier;
    public UnityEvent<bool> Warning;
    private bool isActive;

    public void Initailize()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (condition.Evaluate() && !isActive)
        {
            modifier.Apply();
            isActive = true;
            Warning.Invoke(isActive);
        }

        if (!condition.Evaluate() && isActive)
        {
            modifier.Remove();
            isActive = false;
            Warning.Invoke(isActive);
        }
        
    }
}
