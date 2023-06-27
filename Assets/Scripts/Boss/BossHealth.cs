using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 500f;
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

    public void TakeDamage(float amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 250)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
            animator.SetBool("SecondPhase", true);
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
        Destroy(gameObject, 5.0f);
        GameManager.playerScore += 1000;
    }
}
