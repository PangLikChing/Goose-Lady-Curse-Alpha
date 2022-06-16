using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RainTrigger : MonoBehaviour
{
    public bool InRain;
    public UnityEvent rainEvent;

    private void Start()
    {
        rainEvent.AddListener(IsInRain);
        InRain = false;
        Debug.Log("In rain is " + InRain);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            rainEvent.Invoke();
        }
    }

    public void IsInRain()
    {
        InRain = true;
        Debug.Log("In rain is " + InRain);
    }

    public void NotInRain()
    {
        InRain = false;
        Debug.Log("In rain is " + InRain);
    }
}
