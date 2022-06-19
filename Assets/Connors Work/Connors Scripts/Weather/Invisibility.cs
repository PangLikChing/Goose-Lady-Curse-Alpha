using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    //variable declaration
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        //makes the selected object turn invisible
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
}
