using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{

    private Toggle[] toggles;
    private GameObject[] zombies;

    private ZWHealth healthZW;
    private ZRHealth healthZR;
    private ZTHealth healthZT;
    private BossHealth healthBoss;
    private GameObject player;
    private Pistol pistol;
    private Rifle rifle;
    private Shotgun shotgun;
    private EquippingScript equip;
    private CharacterStats playerStats;

    private bool immortalityActive;
    private bool infiniteAmmoActive;
    private bool instantKillActive;

    void Start() {
        
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();
        pistol = player.GetComponentInChildren<Pistol>(true);
        rifle = player.GetComponentInChildren<Rifle>(true);
        shotgun = player.GetComponentInChildren<Shotgun>(true);
        equip = player.GetComponent<EquippingScript>();

        immortalityActive = false;
        infiniteAmmoActive = false;
        instantKillActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        toggles = GetComponentsInChildren<Toggle>(true);
        zombies = GameObject.FindGameObjectsWithTag("Zombie");

        // se il cheat è attivo, si avrà sempre il massimo della vita
        if(immortalityActive == true)
            playerStats.health = 100;

        // se il cheat è attivo, si avrà sempre il massimo delle munizioni
        if(infiniteAmmoActive == true){

            if(equip.isSlot1Active)
                pistol.currentBullets = 12;

            if(equip.isSlot2Active)
                rifle.currentBullets = 30;

            if(equip.isSlot3Active)
                shotgun.currentBullets = 8;
        }

        // se il cheat è attivo, gli zombie moriranno immediatamente appena colpiti
        if(instantKillActive == true){

            foreach(GameObject zombie in zombies){

                if(healthZW = zombie.GetComponent<ZWHealth>())
                    healthZW.currentHealth = 1;

                if(healthZR = zombie.GetComponent<ZRHealth>())
                    healthZR.currentHealth = 1;

                if(healthZT = zombie.GetComponent<ZTHealth>())
                    healthZT.currentHealth = 1;

                if(healthBoss = zombie.GetComponent<BossHealth>())
                    healthBoss.currentHealth = 1;
            }
        }
    }

    public void ActiveImmortality(){

        foreach(Toggle toggle in toggles){

            if(toggle.gameObject.name == "Immortality"){

                if(toggle.isOn){
                    immortalityActive = true;
                }
                
                if(!toggle.isOn){
                    playerStats.health = 100;
                    immortalityActive = false;
                }
            }
        }
    }

    public void ActiveInfiniteAmmo(){

        foreach(Toggle toggle in toggles){

            if(toggle.gameObject.name == "Ammo"){

                if(toggle.isOn)
                    infiniteAmmoActive = true;
                
                if(!toggle.isOn)
                    infiniteAmmoActive = false;
            }
        }
    }

    public void ActiveInstantKill(){

        foreach(Toggle toggle in toggles){

            if(toggle.gameObject.name == "InstaKill"){

                if(toggle.isOn)
                    instantKillActive = true;
                
                if(!toggle.isOn){

                    instantKillActive = false;

                    foreach(GameObject zombie in zombies){

                        if(healthZW = zombie.GetComponent<ZWHealth>())
                            healthZW.currentHealth = healthZW.maxHealth;

                        if(healthZR = zombie.GetComponent<ZRHealth>())
                            healthZR.currentHealth = healthZR.maxHealth;

                        if(healthZT = zombie.GetComponent<ZTHealth>())
                            healthZT.currentHealth = healthZT.maxHealth;

                        if(healthBoss = zombie.GetComponent<BossHealth>())
                            healthBoss.currentHealth = healthBoss.maxHealth;
                    }
                }
            }
        }
    }
}
