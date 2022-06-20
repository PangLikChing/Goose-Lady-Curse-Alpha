using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Boundary : MonoBehaviour
{
    public UnityEvent EnterBoundary;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            EnterBoundary.Invoke();
        }
    }
}
