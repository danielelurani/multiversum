using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftController : MonoBehaviour
{

    public float shiftDistance = 5f; 
    public float shiftDuration = 1f; 
    
    private Vector3 shiftDirection; 
    private float shiftTimer;
    private bool isShifted;

    private Transform player;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isShifted)
        {
            ShiftBack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {       
            shiftDirection = Vector3.back;

            isShifted= true;
            shiftTimer = Time.time; //tempo allo start dello shift
        }
    }

    private void ShiftBack()
    {
        // calcolo del tempo trascorso
        float elapsedTime = Time.time - shiftTimer;

        // se il tempo trascorso e' minore della durata prevista dello shift
        if (elapsedTime < shiftDuration)
        {
            //calcolo e applico lo shift
            Vector3 shift = shiftDirection * shiftDistance * Time.deltaTime;
            player.transform.position += shift;
        }
        else
        {
            // fine dello shift
            isShifted = false;
        }
    }
}

