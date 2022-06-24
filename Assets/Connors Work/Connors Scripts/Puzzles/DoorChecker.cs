using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    //variable declaration
    private GameObject door;
    private bool KeyObtained;
    private KeyListener keylistener;

    //If the player touches the door checker, destroy it, and check to see 
    //if they obtained the key item or not. If so, deactivate the door, otherwise do nothing.
    void OnDestroy()
    {
        Debug.Log("OnDestroy was hit");
        door = GameObject.Find("Door");
        keylistener = GameObject.Find("KeyListenerObject").GetComponent<KeyListener>();
        KeyObtained = keylistener.GetKeyListener();

        if (KeyObtained == true)
        {
            door.SetActive(false);
            KeyObtained = false;
        }
    }
}
