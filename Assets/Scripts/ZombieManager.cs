using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{

    private GameObject player;
    private ZombieWalkerMovement script;

    // Start is called before the first frame update
    void Start()
    {

        // prendo l'oggetto Player e la sua posizione per passarli allo script
        // ZombieWalkerMovement in modo che lo zombie conosca la posizione
        // del giocatore, che è usata per muoversi vero di lui 
        player = GameObject.Find("Player");
        script = GetComponent<ZombieWalkerMovement>();
        script.playerTransform = player.transform;
    }
}
