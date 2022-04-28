using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public Camera Aim;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private void Start()
    {
        Cursor.visible = false;
    }
    public void ProcessLook(Vector2 input)
    {
        //this is for looking around with the mouse
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Aim.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * xSensitivity);

    }
}
