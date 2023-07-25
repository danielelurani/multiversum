using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{

    private Toggle[] toggles;
    private GameObject player;
    private CharacterStats playerStats;

    private bool immortalityActive;

    void Start() {
        
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();
        immortalityActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        toggles = GetComponentsInChildren<Toggle>(true);

        if(immortalityActive == true)
            playerStats.health = 100;

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
}
