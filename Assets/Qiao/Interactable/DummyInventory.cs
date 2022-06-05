using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInventory : MonoBehaviour
{
    public void AddItem(ScriptableObject item, int stack) //this is for testing delete it after test
    {
        Debug.Log($"{stack} stack of {item} added into the inventory");
    }
}
