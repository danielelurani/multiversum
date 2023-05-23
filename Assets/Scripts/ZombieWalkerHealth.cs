using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalkerHealth : MonoBehaviour
{

    public float maxHealth = 100f;

    [HideInInspector]
    public float currentHealth;

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void TakeDamage(float amount){

        currentHealth -= amount;

        if(currentHealth <= 0.0f){

            animator.SetBool("isDead", true);
            agent.speed = 0.0f;
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject, 5.0f);
    }
}
