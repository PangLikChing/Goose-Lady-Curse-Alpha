using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MountainTrigger : MonoBehaviour
{
    public bool OnMountain;
    public UnityEvent mountainEvent;

    private void Start()
    {
        mountainEvent.AddListener(IsOnMountain);
        OnMountain = false;
        Debug.Log("on mountain is " + OnMountain);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            mountainEvent.Invoke();
        }
    }

    public void IsOnMountain()
    {
        OnMountain = true;
        Debug.Log("on mountain is " + OnMountain);
    }

    public void NotOnMountain()
    {
        OnMountain = false;
        Debug.Log("on mountain is " + OnMountain);
    }
}
