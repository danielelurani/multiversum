using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 500f;
    [SerializeField] public float currentHealth;
    [SerializeField] protected bool isDead;

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    private GameObject bossHealth;
    public BossHealthBar bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        bossHealth = GameObject.Find("BossHealthBar");

       
        
    }

        public void TakeDamage(float amount)
        {

            currentHealth -= amount;

            if (currentHealth <= 250 && !animator.GetBool("FirstPhaseEnding"))
            {
                animator.SetBool("FirstPhaseEnding", true);
                agent.speed = 0.0f;

                StartCoroutine(StartSecondPhase());

            }


            if (currentHealth <= 0.0f)
            {

                if (!animator.GetBool("isDead"))
                    Die();

                animator.SetBool("isDead", true);
                agent.speed = 0.0f;
            }
        }

        private IEnumerator StartSecondPhase()
        {
            yield return new WaitForSeconds(1f);
            agent.speed = 0.0f;
            animator.SetBool("SecondPhase", true);


        }

        public void Die()
        {
            GameManager.playerScore += 5000;
            BossLevelSpawner.zombiesCanSpawn = false;
            GameManager.bossIsDeath = true;
        }



        void Update()
        {


            bossHealthBar.SetHealth(currentHealth);
        }

        public void CheckHealth()
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;

            }

            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

}

