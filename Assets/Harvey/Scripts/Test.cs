using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public UnityEvent<int, int> swapBag;

    public void TestFunction()
    {
        swapBag.Invoke(0, 2);
    }
}
