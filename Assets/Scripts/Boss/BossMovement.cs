using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{

    private Transform player;
    private NavMeshAgent agent;
    public LayerMask whatIsPlayer;

    private Animator animator;

    public float sightRange, attackRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange) AttackPlayer();
        if (!playerInAttackRange) SearchPlayer();

    }

    private void SearchPlayer()
    {
        agent.SetDestination(player.transform.position);

    }


    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        i
    }
}
