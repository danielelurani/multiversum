using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    private GameObject player, pistol, rifle, shotgun;
    private Pistol pistolScript;
    private Rifle rifleScript;
    private Shotgun shotgunScript;
    private EquippingScript equip;

    // Start is called before the first frame update
    void Start()
    {

        // trovo gli elementi necessari nella scena
        player = GameObject.Find("Player");
        pistol = GameObject.Find("Pistol");
        rifle = GameObject.Find("Rifle");
        shotgun = GameObject.Find("Shotgun");

        // dagli oggetti trovati prendo gli script
        pistolScript = pistol.GetComponent<Pistol>();
        rifleScript = rifle.GetComponent<Rifle>();
        shotgunScript = shotgun.GetComponent<Shotgun>();
        equip = player.GetComponent<EquippingScript>();
    }

    // se il giocatore tocca il power up, metti le munizioni delle armi al massimo
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player")){

            if(equip.isSlot1Active)
                pistolScript.currentAmmo = pistolScript.maxAmmo;

            if(equip.isSlot2Active)
                rifleScript.currentAmmo = rifleScript.maxAmmo;

            if(equip.isSlot3Active)
                shotgunScript.currentAmmo = shotgunScript.maxAmmo;
                
            Destroy(gameObject);
        }
    }
}
