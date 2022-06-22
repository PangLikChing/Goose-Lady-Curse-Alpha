using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class EmojiBubble : MonoBehaviour
{
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
        }
    }
}
