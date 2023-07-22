using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private GameObject player;
    private CharacterStats playerStats;

    [SerializeField] private int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerStats.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
