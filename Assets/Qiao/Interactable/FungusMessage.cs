using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
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
