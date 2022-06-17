using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ForestTrigger : MonoBehaviour
{
    public bool OnForest;
    public UnityEvent forestEvent;

    private void Start()
    {
        forestEvent.AddListener(IsInForest);
        OnForest = false;
        Debug.Log("In Forest is " + OnForest);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            forestEvent.Invoke();
        }
    }

    public void IsInForest()
    {
        OnForest = true;
        Debug.Log("In Forest is " + OnForest);
    }

    public void NotInForest()
    {
        OnForest = false;
        Debug.Log("In Forest is " + OnForest);
    }

}
