using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZRHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

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

            if(!animator.GetBool("isDead"))
                Die();

            animator.SetBool("isDead", true);
            agent.speed = 0.0f;
        }
    }

    public void Die(){
        Destroy(gameObject, 5.0f);
        GameManager.playerScore += 200;
        GameManager.zombiesAlive --;
    }
}
