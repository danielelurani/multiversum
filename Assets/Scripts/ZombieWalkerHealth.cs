using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalkerHealth : MonoBehaviour
{

    public float maxHealth = 50f;

    [HideInInspector]
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount){

        currentHealth -= amount;

        if(currentHealth <= 0.0f){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }
}
