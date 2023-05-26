using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWDamage : MonoBehaviour
{

    public int damage = 20;

    public CharacterStats playerStats;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
            playerStats.TakeDamage(damage);
    }
}
