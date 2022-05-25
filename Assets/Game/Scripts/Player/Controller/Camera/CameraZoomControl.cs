using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraZoomControl : MonoBehaviour
{
    private CinemachineVirtualCamera currentCam;
    private float targetFov;
    public float zoomSensitivity = -0.01f;
    public float zoomSpeed = 10f;
    public float maxFov = 30;
    public float minFov = 10;
    public float deadZone = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = GetComponent<CinemachineVirtualCamera>();
        transform.parent.GetComponent<PlayerFSM>().inputHandler.ZoomEvent += ZoomCamera;
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
