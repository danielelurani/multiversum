using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    // Referenza alla classe PlayerInput
     private PlayerInput playerInput;
     private PlayerInput.OnFootActions onFoot;

     private PlayerMotor motor;
     private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // Evento che si attiva ogni volta che viene usato jump
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate(){
        
        // Il playermotor si muove utilizzando i valori del movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate() {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    // Abilito la actionmap per utilizzare gli input
    private void OnEnable() {
        
        onFoot.Enable();
    }

    private void OnDisable() {
        
        onFoot.Disable();
    }
}
