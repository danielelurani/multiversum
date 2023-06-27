using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    private GameObject player;
    private Pistol pistol;
    private Rifle rifle;
    private Shotgun shotgun;
    private EquippingScript equip;
    private GameObject secondCamera;

    // Start is called before the first frame update
    void Start()
    {
        secondCamera = GameObject.Find("Second Camera");

        // trovo gli elementi necessari nella scena
        player = GameObject.Find("Player");
        
        pistol = secondCamera.GetComponentInChildren<Pistol>(true);
        rifle = secondCamera.GetComponentInChildren<Rifle>(true);
        shotgun = secondCamera.GetComponentInChildren<Shotgun>(true);
        equip = player.GetComponent<EquippingScript>();

        // distruggi l'oggetto se non viene raccolto entro x secondi
        Destroy(gameObject, 30f);
    }

    // se il giocatore tocca il power up, metti le munizioni delle armi al massimo
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player")){
            
            if(equip.isSlot1Active)
                pistol.currentAmmo = pistol.maxAmmo;

            if(equip.isSlot2Active)
                rifle.currentAmmo = rifle.maxAmmo;

            if(equip.isSlot3Active)
                shotgun.currentAmmo = shotgun.maxAmmo;
                
            Destroy(gameObject);
        }
    }
}
