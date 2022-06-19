using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySetter : MonoBehaviour
{
    //When the key setter is destroyed, set the key listener flag in the world after finding it, to true
    void OnDestroy()
    {
        GameObject.Find("KeyListenerObject").GetComponent<KeyListener>().SetKeyListener(true);
    }
}
