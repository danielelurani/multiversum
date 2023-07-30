using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunPickUp : MonoBehaviour
{
    private GameObject player;
    private EquippingScript equip;

    private GameObject textObject;
    private GameObject insufficentScore;
    private GameObject buyAmmoText;

    private int cost = 3000;
    private int ammoCost = 1000;

    [SerializeField] private float pickUpRange = 2f;

    void Start(){

        // trovo il giocatore ed il suo script necessario
        player = GameObject.Find("Player");
        equip = player.GetComponent<EquippingScript>();

        // trovo il testo che segnala la mancanza di punteggio
        insufficentScore = GameObject.Find("ShotgunInsufficientScore");
        insufficentScore.SetActive(false);

        // trovo il testo per prendere il fucile
        textObject = GameObject.Find("ShotgunPickUpText");
        textObject.SetActive(false);

        //trovo il testo per comprare le munizioni
        buyAmmoText = GameObject.Find("ShotgunRefillAmmoText");
        buyAmmoText.SetActive(false);
    }

    void Update(){

        // calcolo distanza dell'arma dal giocatore
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // controlli per la funzione per prendere il fucile dal muro
        // se la distanza è minore del range e se non ho già il fucile
        if(distanceToPlayer <= pickUpRange && equip.slotEquippedATM != 3 && !equip.isSlot3Active)
        {
            
            // se ho abbastanza punti
            if(GameManager.playerScore >= cost){

                if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)){

                    PickUp();
                }
                
                textObject.SetActive(true);
            } else {
                
                insufficentScore.SetActive(true);
            }
        } 

        // controlli per la funzione per comprare le munizioni del fucile
        // se la distanza è minore del range, se ho già il fucile ed è equipaggiato al mmento,
        // se non ho già il massimo delle munizioni
        else if(distanceToPlayer <= pickUpRange &&
         equip.slotEquippedATM == 3 &&
         equip.isSlot3Active &&
         GameManager.shotgunScript.currentAmmo < GameManager.shotgunScript.maxAmmo)
        {

            // se ho abbastanza punti
            if(GameManager.playerScore >= ammoCost){

                if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)){
                    RefillAmmo();
                }

                buyAmmoText.SetActive(true);
            } else {

                insufficentScore.SetActive(true);
            }
        } 
        else 
        {
            textObject.SetActive(false);
            buyAmmoText.SetActive(false);
            insufficentScore.SetActive(false);
        }
    }

    private void PickUp(){

        if(equip.numberOfSlotActive == 1){

            equip.Slot3(true);
            equip.Equip3();
            equip.numberOfSlotActive = 2;
            GameManager.playerScore -= cost;
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

            GameManager.playerScore -= cost;
        }
    }
    
    private void RefillAmmo(){

        GameManager.shotgunScript.currentAmmo = GameManager.shotgunScript.maxAmmo;
        GameManager.playerScore -= ammoCost;
    }
}
