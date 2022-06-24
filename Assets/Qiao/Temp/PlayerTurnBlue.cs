using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBlue : MonoBehaviour
{
    private Color playerOriginalColor;
    private Color playerOriginalColor1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Color temp = other.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color;
            playerOriginalColor = new Color(temp.r, temp.g, temp.b, temp.a);
            other.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;

            temp = other.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color;
            playerOriginalColor1 = new Color(temp.r, temp.g, temp.b, temp.a);
            other.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
        }
             
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = playerOriginalColor;
            other.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = playerOriginalColor1;
        }
    }

}
