using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class QuestManager : MonoBehaviour
{
    //initialize in the inspector with the first quest
    public Quest currentQuest;

    private void OnEnable()
    {
        //save system need assign the current quest according to progress.
    }

    public void ActivateCurrentDialog()
    {
        if (currentQuest.stage == Quest.Stage.outro && currentQuest.nextQuest != null)
        {
            currentQuest = currentQuest.nextQuest;
        }
        currentQuest.Dialog();
    }
}
