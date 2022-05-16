using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 500;
    public float speed = 5;
    public float jumpForce = 5;


    private float mouseX = 0;
    private float calibrateX = 0;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime - calibrateX;
        transform.Rotate(Vector3.up, mouseX);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        }
    }

    public void Calibrate()
    {
        calibrateX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }
}
