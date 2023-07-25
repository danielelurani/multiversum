using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWHealth : MonoBehaviour
{

    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth;

    private float random;

    private GameObject health, ammo, instantKill;
    private AudioSource audioZW;

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        health = Resources.Load<GameObject>("Prefabs/HealthPU");
        ammo = Resources.Load<GameObject>("Prefabs/MaxAmmoPU");
        instantKill = Resources.Load<GameObject>("Prefabs/InstantKillPU");

        audioZW = GetComponent<AudioSource>();
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

    void Update()
    {
        random = Random.Range(0f,1f);
    }

    public void Die(){

        audioZW.enabled = false;

        Destroy(gameObject, 5.0f);
        GameManager.playerScore += 100;
        GameManager.zombiesAlive --;
        EnemySpawner.zombieWalkerCount --;

        if(random > 0.15f && random <= 0.25f){

            Vector3 position = transform.position;
            position.y += 0.5f;
            Vector3 newPosition = position;
            GameObject powerUp = Instantiate(ammo, newPosition, Quaternion.identity);
        }

        if(random >= 0.1f && random <= 0.15){

            Vector3 position = transform.position;
            position.y += 0.5f;
            Vector3 newPosition = position;
            GameObject powerUp = Instantiate(health, newPosition, Quaternion.identity);
        }

        if(random >= 0.05f && random <= 0.07){

            Vector3 position = transform.position;
            position.y += 0.5f;
            Vector3 newPosition = position;
            GameObject powerUp = Instantiate(health, newPosition, Quaternion.identity);
        }
    }
}
