using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunPickUp : MonoBehaviour
{
    private GameObject player;
    private EquippingScript equip;
    private GameObject textObject;
    private Text text;

    [SerializeField] private float pickUpRange = 2f;

    void Start(){

        // trovo il giocatore ed il suo script necessario
        player = GameObject.Find("Player");
        equip = player.GetComponent<EquippingScript>();

        textObject = GameObject.Find("PickUpText");
        text = textObject.GetComponent<Text>();
        text.enabled = false;
    }

    void Update(){

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if(Input.GetKeyDown(KeyCode.E) && distanceToPlayer <= pickUpRange)
            PickUp();
        
        if(distanceToPlayer <= pickUpRange)
            text.enabled = true;
        else
            text.enabled = false;
    }

    private void PickUp(){

        if(equip.numberOfSlotActive == 1){

            equip.Slot3(true);
            equip.numberOfSlotActive = 2;
        }
        else{

            switch (equip.slotEquippedATM)
            {
                case 1:
                    equip.Slot1(false);
                    equip.Slot3(true);
                    equip.Equip3();
                    break;
                case 2:
                    equip.Slot2(false);
                    equip.Slot3(true);
                    equip.Equip3();
                    break;
                default: break;
            }
        }
    }
}
