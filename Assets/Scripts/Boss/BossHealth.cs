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
    [SerializeField] private GameObject bossFire;

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    private GameObject bossHealthBar;
    public BossHealthBar bossHealthBarScript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        bossHealthBar = GameObject.Find("BossHealthBar");
        bossHealthBarScript = bossHealthBar.GetComponent<BossHealthBar>();
        bossHealthBarScript.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        bossHealthBarScript.SetHealth(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 250 && !animator.GetBool("SecondPhase"))
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
        animator.SetBool("SecondPhase", true);
        agent.speed = 3.5f;
        bossFire.SetActive(true);
    }

    public void Die()
    {
        GameManager.playerScore += 5000;
        BossLevelSpawner.zombiesCanSpawn = false;
        GameManager.bossIsDeath = true;
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

