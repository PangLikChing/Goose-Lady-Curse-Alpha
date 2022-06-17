using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeachTrigger : MonoBehaviour
{
    public bool OnBeach;
    public UnityEvent beachEvent;

    private void Start()
    {
        beachEvent.AddListener(IsOnBeach);
        OnBeach = false;
        Debug.Log("On Beach is " + OnBeach);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            beachEvent.Invoke();
        }
    }

    public void IsOnBeach()
    {
        OnBeach = true;
        Debug.Log("On Beach is " + OnBeach);
    }

    public void NotOnBeach()
    {
        OnBeach = false;
        Debug.Log("On Beach is " + OnBeach);
    }

}
