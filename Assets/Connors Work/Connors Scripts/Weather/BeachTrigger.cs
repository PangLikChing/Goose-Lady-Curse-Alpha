using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeachTrigger : MonoBehaviour
{
    //variable declaration
    public bool OnBeach;
    public UnityEvent beachEvent;

    private void Start()
    {
        beachEvent.AddListener(IsOnBeach);
        OnBeach = false;
        Debug.Log("On Beach is " + OnBeach);
    }

    //if the beach trigger is touched by the player, send out a event
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            beachEvent.Invoke();
        }
    }

    //set the beach trigger flag to be true.
    public void IsOnBeach()
    {
        OnBeach = true;
        Debug.Log("On Beach is " + OnBeach);
    }

    //set the beach trigger flag to be false.
    public void NotOnBeach()
    {
        OnBeach = false;
        Debug.Log("On Beach is " + OnBeach);
    }

}
