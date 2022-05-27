using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Controls the camera zoom by changing FOV
/// </summary>
public class CameraZoomControl : MonoBehaviour
{
    private CinemachineVirtualCamera currentCam;
    private float targetFov;
    [Tooltip("Amount of zoom per scroll")]
    public float zoomSensitivity = 0.01f;
    [Tooltip("Camera fov change rate")]
    public float zoomSpeed = 10f;
    [Tooltip("Zoom out limit")]
    public float maxFov = 30;
    [Tooltip("Zoom in limit")]
    public float minFov = 10;
    [Tooltip("FOV snap on threshold")]
    public float deadZone = 0.001f;
    [Tooltip("Input reader reference")]
    public InputReader inputReader;
    // Start is called before the first frame update
    void Start()
    {
        currentCam = GetComponent<CinemachineVirtualCamera>();
        inputReader.ZoomEvent += ZoomCamera;
        targetFov = currentCam.m_Lens.FieldOfView;
    }

    private void Update()
    {
        if (Mathf.Abs(targetFov - currentCam.m_Lens.FieldOfView) < deadZone)
        {
            currentCam.m_Lens.FieldOfView = targetFov;
        }
        else 
        {
            currentCam.m_Lens.FieldOfView = Mathf.Lerp(currentCam.m_Lens.FieldOfView, targetFov, zoomSpeed*Time.deltaTime);
        }
    }

    public void ZoomCamera(float zoom)
    {
        if (CinemachineCore.Instance.IsLive(currentCam))
        {
            targetFov += zoom*zoomSpeed;
            targetFov = Mathf.Clamp(targetFov, minFov, maxFov);
        }
    }
}
