using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 500f;
    [SerializeField] public float currentHealth;

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void TakeDamage(float amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 250)
        { 
            animator.SetBool("SecondPhase", true);
            agent.speed = 3.5f;
        }

        if (currentHealth <= 0.0f)
        {

            if (!animator.GetBool("isDead"))
                Die();

            animator.SetBool("isDead", true);
            agent.speed = 0.0f;
        }
    }

    public void Die()
    {
        GameManager.playerScore += 5000;
        BossLevelSpawner.zombiesCanSpawn = false;
        GameManager.bossIsDeath = true;
    }
}
