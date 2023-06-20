using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiflePickUp : MonoBehaviour
{
    private GameObject player;
    private EquippingScript equip;

    private GameObject textObject;
    private GameObject insufficentScore;
    private GameObject buyAmmoText;

    private int cost = 2000;        // costo per comprare il fucile
    private int ammoCost = 500;     // costo per comprare le munizioni

    [SerializeField] private float pickUpRange = 2f;

    void Start(){

        // trovo il giocatore ed il suo script necessario
        player = GameObject.Find("Player");
        equip = player.GetComponent<EquippingScript>();

        // trovo il testo che segnala la mancanza di punteggio
        insufficentScore = GameObject.Find("RifleInsufficientScore");
        insufficentScore.SetActive(false);

        // trovo il testo per prendere il fucile
        textObject = GameObject.Find("RiflePickUpText");
        textObject.SetActive(false);

        //trovo il testo per comprare le munizioni
        buyAmmoText = GameObject.Find("RifleRefillAmmoText");
        buyAmmoText.SetActive(false);
    }

    void Update(){

        // calcolo distanza dell'arma dal giocatore
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // controlli per la funzione per prendere il fucile dal muro
        // se la distanza è minore del range e se non ho già il fucile
        if(distanceToPlayer <= pickUpRange && equip.slotEquippedATM != 2 && !equip.isSlot2Active){

            // se ho abbastanza punti
            if(GameManager.playerScore >= cost){

                if(Input.GetKeyDown(KeyCode.E)){

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
         equip.slotEquippedATM == 2 &&
         equip.isSlot2Active &&
         GameManager.rifleScript.currentAmmo < GameManager.rifleScript.maxAmmo)
         {

            // se ho abbastanza punti
            if(GameManager.playerScore >= ammoCost){

                if(Input.GetKeyDown(KeyCode.E)){
                    RefillAmmo();
                }

                buyAmmoText.SetActive(true);
            } else {

                insufficentScore.SetActive(true);
            }
        } else 
        {
            textObject.SetActive(false);
            buyAmmoText.SetActive(false);
            insufficentScore.SetActive(false);
        }
    }


    // funzione per equipaggiare il fucile
    private void PickUp(){

        if(equip.numberOfSlotActive == 1){

            equip.Slot2(true);
            equip.numberOfSlotActive = 2;
            GameManager.playerScore -= cost;
        }
        else{

            switch (equip.slotEquippedATM)
            {
                case 1:
                    equip.Slot1(false);
                    equip.Slot2(true);
                    equip.Equip2();
                    break;
                case 3:
                    equip.Slot3(false);
                    equip.Slot2(true);
                    equip.Equip2();
                    break;
                default: break;
            }

            GameManager.playerScore -= cost;
        }
    }

    private void RefillAmmo(){

        GameManager.rifleScript.currentAmmo = GameManager.rifleScript.maxAmmo;
        GameManager.playerScore -= ammoCost;
    }

}
