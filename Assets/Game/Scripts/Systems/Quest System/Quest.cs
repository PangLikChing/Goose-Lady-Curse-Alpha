using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;

[RequireComponent(typeof(Flowchart))]
public class Quest : MonoBehaviour
{
    private Flowchart dialog;
    public string description;
    public bool objectiveComplete;
    public Quest nextQuest;
    public UnityEvent<string> UpdateQuestHint;
    public List<Sprite> emojiHint;
    public enum Stage
    {
        intro,
        ongoing,
        outro
    }
    public Stage stage;

    private void OnEnable()
    {
        //save system needs to assign the stage according to progression
        stage = Stage.intro;
        dialog = GetComponent<Flowchart>();
    }

    public void Dialog()
    {
        switch (stage)
        {
            case Stage.intro:
                dialog.SendFungusMessage("intro");
                OnQuestIncomplete();
                break;
            case Stage.ongoing:
                dialog.SendFungusMessage("ongoing");
                break;
            case Stage.outro:
                //dialog.SendFungusMessage("outro");
                break;

        }
    }

    public void SkipDialog()
    {
        dialog.StopAllBlocks();
        if (stage == Stage.intro)
        {
            OnQuestIncomplete();
        }
    }

    public void OnQuestComplete()
    {
        stage = Stage.outro;
        objectiveComplete = true;
        UpdateQuestHint.Invoke("Return to statue");//TODO: change the hard coded message later
    }

    public void OnQuestIncomplete()
    {
        stage = Stage.ongoing;
        objectiveComplete = false;
        UpdateQuestHint.Invoke(description);
    }
}
