using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWDamage : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    private GameObject player;
    private CharacterStats playerStats;

    void Start(){

        // prendo l'oggetto player e il suo componente CharacterStats per poi usarlo nella funzione OnTriggerEnter
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
            playerStats.TakeDamage(damage);
    }
}
