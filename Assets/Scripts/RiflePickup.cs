using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiflePickup : MonoBehaviour
{
    public EquippingScript equip;
    public Transform Player;
    public Text text;

    public float pickUpRange = 2f;

    void Start(){

        text.enabled = false;
    }

    void Update(){

        float distanceToPlayer = Vector3.Distance(Player.position, transform.position);

        if(Input.GetKeyDown(KeyCode.E) && distanceToPlayer <= pickUpRange)
            PickUp();
        
        if(distanceToPlayer <= pickUpRange)
            text.enabled = true;
        else
            text.enabled = false;
    }

    private void PickUp(){

        equip.ActiveSlot2();
    }

}
