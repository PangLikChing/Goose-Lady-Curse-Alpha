using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;
using Project.Build.Commands;

public class ObjectiveTracker : MonoBehaviour
{
    public Flowchart targetFlowChart;
    public Item objective;
    public int targetCount;
    [SerializeField, ReadOnly]
    private bool completed;
    [SerializeField, ReadOnly]
    private float currentCount;

    public void PickupObjective(Item item, int stack)
    {

        if (objective.name == item.name)
        {
            currentCount += stack;
        }

        if (currentCount >= targetCount && !completed)
        {
            targetFlowChart.SendFungusMessage(objective.itemDisplayName);// display a dialog box object complete return to base
            completed = true;
        }
    }

    public void DropoffObjective(Item item, int stack)
    {

        if (objective.name == item.name)
        {
            currentCount -= stack;
        }
        if (currentCount < targetCount && completed)
        {
            // display a dialog box telling player to pick up the objective
            completed = false;
        }
    }
}
