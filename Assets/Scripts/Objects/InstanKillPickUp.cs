using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanKillPickUp : MonoBehaviour
{
    private GameObject player;
    private GameObject[] zombies;
    private ZWHealth healthZW;
    private ZRHealth healthZR;
    private ZTHealth healthZT;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player")){

            zombies = GameObject.FindGameObjectsWithTag("Zombie");

            ApplyInstantKill();
                
            Destroy(gameObject);
        }
    }

    private void ApplyInstantKill(){

        foreach(GameObject zombie in zombies){

            if(healthZW = zombie.GetComponent<ZWHealth>())
                healthZW.currentHealth = 1;

            if(healthZR = zombie.GetComponent<ZRHealth>())
                healthZR.currentHealth = 1;

            if(healthZT = zombie.GetComponent<ZTHealth>())
                healthZT.currentHealth = 1;
        }
    }
}
