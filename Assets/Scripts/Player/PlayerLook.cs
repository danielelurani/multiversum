using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    
    public Camera cam;

    private float xRotation = 0f;

    // Sensibilità visuale orizontale e verticale
    public float xSensitivity = 15f;
    public float ySensitivity = 15f;

    public void ProcessLook(Vector2 input)
    {

        float mouseX = input.x;
        float mouseY = input.y;

        // rotazione camera
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // applica alla camera
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //ruota giocatore a destra o sinistra
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }

   
}
