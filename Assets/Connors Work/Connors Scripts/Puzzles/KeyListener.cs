using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    private bool KeyObtained;

    // Start is called before the first frame update
    void Start()
    {
        KeyObtained = false;
    }

    public bool GetKeyListener()
    {
        return KeyObtained;
    }

    public void SetKeyListener(bool newKeyObtained)
    {
        KeyObtained = newKeyObtained;
    }

}
