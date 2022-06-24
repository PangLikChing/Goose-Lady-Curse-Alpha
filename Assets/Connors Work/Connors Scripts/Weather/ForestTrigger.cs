using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ForestTrigger : MonoBehaviour
{
    //variable declaration
    public bool OnForest;
    public UnityEvent forestEvent;

    private void Start()
    {
        forestEvent.AddListener(IsInForest);
        OnForest = false;
        Debug.Log("In Forest is " + OnForest);
    }

    //if the forest trigger is touched by the player, send out a event
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            forestEvent.Invoke();
        }
    }

    //set the forest trigger flag to be true.
    public void IsInForest()
    {
        OnForest = true;
        Debug.Log("In Forest is " + OnForest);
    }

    //set the forest trigger flag to be false.
    public void NotInForest()
    {
        OnForest = false;
        Debug.Log("In Forest is " + OnForest);
    }

}
