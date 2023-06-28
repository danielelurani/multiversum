using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsPlayer;

    private Animator animator;

    public float sightRange, attackRange;
    public bool playerInAttackRange;
   
    private float maxTime = 0.5f;
  
    private float timer = 0.0f;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange)
            AttackPlayer();

        if (!playerInAttackRange) 
            SearchPlayer();
     
        if (animator.GetBool("SecondPhase"))
        {
            
        }

    }

    private void SearchPlayer()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        agent.SetDestination(player.position);

    }


    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        animator.SetBool("Attack", true);


    }
}
