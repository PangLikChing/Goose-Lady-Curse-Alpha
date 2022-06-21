using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
[RequireComponent(typeof(Flowchart))]
public class Quest : MonoBehaviour
{
    private Flowchart dialog;
    public string description;
    public bool objectiveComplete;
    public Quest nextQuest;
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
                stage++;
                break;
            case Stage.ongoing:
                dialog.SendFungusMessage("ongoing");
                break;
            case Stage.outro:
                //dialog.SendFungusMessage("outro");
                break;

        }
    }
}
