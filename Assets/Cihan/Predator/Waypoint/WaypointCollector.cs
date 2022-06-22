using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollector : MonoBehaviour
{
    public Transform[] allWaypoints;
    public void Awake()
    {
        allWaypoints = this.transform.GetComponentsInChildren<Transform>();
    }
}
