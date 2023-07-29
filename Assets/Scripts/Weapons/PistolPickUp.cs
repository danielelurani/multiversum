using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolPickUp : MonoBehaviour
{
    private GameObject player;
    private EquippingScript equip;

    private GameObject textObject;
    private GameObject insufficentScore;
    private GameObject buyAmmoText;

    private int cost = 500;        // costo per comprare il fucile
    private int ammoCost = 200;     // costo per comprare le munizioni

    [SerializeField] private float pickUpRange = 2f;

    void Start(){

        // trovo il giocatore ed il suo script necessario
        player = GameObject.Find("Player");
        equip = player.GetComponent<EquippingScript>();

        // trovo il testo che segnala la mancanza di punteggio
        insufficentScore = GameObject.Find("PistolInsufficientScore");
        insufficentScore.SetActive(false);

        // trovo il testo per prendere il fucile
        textObject = GameObject.Find("PistolPickUpText");
        textObject.SetActive(false);

        //trovo il testo per comprare le munizioni
        buyAmmoText = GameObject.Find("PistolRefillAmmoText");
        buyAmmoText.SetActive(false);
    }

    void Update(){

        // calcolo distanza dell'arma dal giocatore
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // controlli per la funzione per prendere il fucile dal muro
        // se la distanza è minore del range e se non ho già il fucile
        if(distanceToPlayer <= pickUpRange && equip.slotEquippedATM != 1 && !equip.isSlot1Active){

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

        // controlli per la funzione per comprare le munizioni della pistola
        // se la distanza è minore del range, se ho già la pistola ed è equipaggiata al momento,
        // se non ho già il massimo delle munizioni
        else if(distanceToPlayer <= pickUpRange &&
         equip.slotEquippedATM == 1 &&
         equip.isSlot1Active &&
         GameManager.pistolScript.currentAmmo < GameManager.pistolScript.maxAmmo)
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
        } else 
        {
            textObject.SetActive(false);
            buyAmmoText.SetActive(false);
            insufficentScore.SetActive(false);
        }
    }


    // funzione per equipaggiare il fucile
    private void PickUp(){

        switch (equip.slotEquippedATM)
        {
            case 2:
                equip.Slot2(false);
                equip.Slot1(true);
                equip.Equip1();
                break;
            case 3:
                equip.Slot3(false);
                equip.Slot1(true);
                equip.Equip1();
                break;
            default: break;
        }

        GameManager.playerScore -= cost;
    }

    private void RefillAmmo(){

        GameManager.pistolScript.currentAmmo = GameManager.pistolScript.maxAmmo;
        GameManager.playerScore -= ammoCost;
    }
}