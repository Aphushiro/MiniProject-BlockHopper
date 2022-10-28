using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float sensitivity = 300f;
    float xRot = 0f;

    public Transform playerTransform;

    void Start()
    {
        //Lock cursor to the middle of the screen, and turns it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        // Rotating the camera along the local x-axis
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        // Rotating the player around the y-axis when the mouse is moved horizontally
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
