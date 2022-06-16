using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    private MeshRenderer mesh;
    //public GameObject objectToTurnInvisible;
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
}
