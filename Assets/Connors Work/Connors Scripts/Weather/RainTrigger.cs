using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RainTrigger : MonoBehaviour
{
    //variable declaration
    public bool InRain;
    public UnityEvent rainEvent;

    private void Start()
    {
        rainEvent.AddListener(IsInRain);
        InRain = false;
        Debug.Log("In rain is " + InRain);
    }

    //if the rain trigger is touched by the player, send out a event
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            rainEvent.Invoke();
        }
    }

    //set the rain trigger flag to be true.
    public void IsInRain()
    {
        InRain = true;
        Debug.Log("In rain is " + InRain);
    }

    //set the rain trigger flag to be false.
    public void NotInRain()
    {
        InRain = false;
        Debug.Log("In rain is " + InRain);
    }
}
