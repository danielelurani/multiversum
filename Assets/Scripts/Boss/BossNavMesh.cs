using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossNavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private GameObject player;
    
    public Animator animator;
    private float maxTime = 0.5f;
    private float distance;
    private float timer = 0.0f;
    private float interval = 1f;
    public float launchTimer = 0.0f;

  
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");

        

    }
  
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        launchTimer += Time.deltaTime;

        if (timer < 0.0f)
        {
            navMeshAgent.destination = player.transform.position;
            timer = maxTime;
        }

        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

        distance = Vector3.Distance(player.transform.position, transform.position);

       
        if(animator.GetBool("SecondPhase")) {
            navMeshAgent.speed = 3.5f;
        }
       
        

        if (distance <= 2.0f)
        {
            AttackPlayer();
        }
        else
            animator.SetBool("Attack", false);
        

        if(launchTimer >= 10f && animator.GetBool("SecondPhase") && distance >= 5f)
            ThrowObject();


    }

    private void AttackPlayer()
    {
        
        Vector3 directionToTarget = player.transform.position - transform.position;
        directionToTarget.y = 0f;

        navMeshAgent.SetDestination(transform.position);

        if (!animator.GetBool("isDead"))
        {

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);

            animator.SetBool("Attack", true);
        }
    }
    
    private void ThrowObject()
    {
        Vector3 directionToTarget = player.transform.position - transform.position;
        directionToTarget.y = 0f;

        navMeshAgent.SetDestination(transform.position);
        navMeshAgent.speed = 0.0f;

        if (!animator.GetBool("isDead"))
        {

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);

            animator.SetBool("Throw", true);
        }

        //launchTimer = 0f;
        //animator.SetBool("Throw", false);
        //navMeshAgent.speed = 3.5f;
    }
}

