using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;
using Project.Build.Commands;

public class ItemQuest : Quest
{ 
    public Item objective;
    public int targetCount;
    [SerializeField, ReadOnly]
    private float currentCount;

    public void PickupObjective(Item item, int stack)
    {
        Debug.Log(objective.name);
        if (objective.name == item.name)
        {
            currentCount += stack;
        }

        if (currentCount >= targetCount && !objectiveComplete)
        {
            stage = Stage.outro;
            objectiveComplete = true;
        }
    }

    public void DropoffObjective(Item item, int stack)
    {

        if (objective.name == item.name)
        {
            currentCount -= stack;
        }
        if (currentCount < targetCount && objectiveComplete)
        {
            // display a dialog box telling player to pick up the objective
            stage = Stage.ongoing;
            objectiveComplete = false;
        }
    }
}
