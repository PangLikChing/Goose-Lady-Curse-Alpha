using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MountainTrigger : MonoBehaviour
{
    //variable declaration
    public bool OnMountain;
    public UnityEvent mountainEvent;

    private void Start()
    {
        mountainEvent.AddListener(IsOnMountain);
        OnMountain = false;
        Debug.Log("on mountain is " + OnMountain);
    }

    //if the mountain trigger is touched by the player, send out a event
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            mountainEvent.Invoke();
        }
    }

    //set the mountain trigger flag to be true.
    public void IsOnMountain()
    {
        OnMountain = true;
        Debug.Log("on mountain is " + OnMountain);
    }

    //set the mountain trigger flag to be false.
    public void NotOnMountain()
    {
        OnMountain = false;
        Debug.Log("on mountain is " + OnMountain);
    }
}
