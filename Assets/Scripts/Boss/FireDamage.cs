using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{

    [SerializeField] private int damage = 5;
    private GameObject player;
    private CharacterStats playerStats;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // prendo l'oggetto player e il suo componente CharacterStats per poi usarlo nella funzione OnTriggerEnter
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        
        if(other.tag == "Player" && timer >= 1f){

            playerStats.TakeDamage(damage);
            timer = 0f;
        }
    }
}
