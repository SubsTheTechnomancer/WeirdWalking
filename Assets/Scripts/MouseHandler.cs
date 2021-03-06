using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    public Transform player;
    
    private float xRotation = 0.0f, yRotation = 0.0f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y")*verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90,90);

        cam.transform.eulerAngles = new Vector3(xRotation,yRotation,0.0f);
        player.eulerAngles = new Vector3(0,yRotation,0);
    }
}
