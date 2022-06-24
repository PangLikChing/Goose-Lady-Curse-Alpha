using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : Structure
{
    public QuestManager questManager;
    public override void Interact()
    {
        base.Interact();
        questManager.ActivateCurrentDialog();
    }
}
