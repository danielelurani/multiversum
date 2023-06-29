using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    Animator animator;

    private float maxTime = 0.5f;
    private float distance;
    private float timer = 0.0f;

    public bool inAttackRange;
    int k = 0;
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
        if (timer < 0.0f)
        {
            navMeshAgent.destination = player.transform.position;
            timer = maxTime;
        }

        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 3f)
        {
            AttackPlayer();
        }
        else
            animator.SetBool("Attack", false);


        /*
        if (animator.GetBool("SecondPhase"))
        {
            k++;

            if (k % 20 == 0)
            {
                    navMeshAgent.SetDestination(transform.position);
                    animator.SetBool("Throw", true);
                }
            }
   */
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
    
}

