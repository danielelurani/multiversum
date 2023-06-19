using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    Animator animator;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = player.transform.position;
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }
}
