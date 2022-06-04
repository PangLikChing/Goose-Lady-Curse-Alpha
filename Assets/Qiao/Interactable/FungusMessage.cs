using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// The GameObject will send a message to a Fungus flowchart OnDestory
/// </summary>
public class FungusMessage : MonoBehaviour
{
    public string message;
    public Flowchart targetFlowChart;

    public void OnDestroy()
    {
        if(targetFlowChart!=null)
            targetFlowChart.SendFungusMessage(message);
    }
}
