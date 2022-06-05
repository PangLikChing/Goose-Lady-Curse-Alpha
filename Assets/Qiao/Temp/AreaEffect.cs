using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    public List<Modifier> modifiers;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(Modifier modifier in modifiers)
            {
                modifier.Apply();
            }
                
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Modifier modifier in modifiers)
            {
                modifier.Remove();
            }
        }
    }
}
