using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    //initialize in the inspector with the first quest
    public Quest currentQuest;
    public InputReader inputReader;

    private void OnEnable()
    {
        //save system need assign the current quest according to progress.
        inputReader.SkipDialogEvent += SkipDialog;
    }

    private void OnDisable()
    {
        inputReader.SkipDialogEvent -= SkipDialog;
    }

    public void ActivateCurrentDialog()
    {
        if (currentQuest.stage == Quest.Stage.outro && currentQuest.nextQuest != null)
        {
            currentQuest = currentQuest.nextQuest;
        }
        currentQuest.Dialog();
    }

    public void SkipDialog()
    {
        currentQuest.SkipDialog();
    }
}
