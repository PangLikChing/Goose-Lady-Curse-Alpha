using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    //variable declaration
    private bool KeyObtained;

    // Start is called before the first frame update
    void Start()
    {
        KeyObtained = false;
    }

    //returns the key listener flag
    public bool GetKeyListener()
    {
        return KeyObtained;
    }

    //Sets the key listeners flag to be equal to the bool incoming.
    public void SetKeyListener(bool newKeyObtained)
    {
        KeyObtained = newKeyObtained;
    }

}
