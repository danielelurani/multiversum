using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private GameObject player;
    private CharacterStats playerStats;

    // Start is called before the first frame update
    void Start()
    {

        // trovo gli elementi necessari nella scena
        player = GameObject.Find("Player");

        // dagli oggetti trovati prendo gli script
        playerStats = player.GetComponent<CharacterStats>();
    }

    // se il giocatore tocca il power up, metti le munizioni delle armi al massimo
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player")){

            playerStats.health = playerStats.maxHealth;
                
            Destroy(gameObject);
        }
    }
}
