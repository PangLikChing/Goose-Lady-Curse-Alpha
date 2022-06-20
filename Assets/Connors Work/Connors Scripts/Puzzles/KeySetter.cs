using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySetter : MonoBehaviour
{
    void OnDestroy()
    {
        GameObject.Find("KeyListenerObject").GetComponent<KeyListener>().SetKeyListener(true);
    }
}
