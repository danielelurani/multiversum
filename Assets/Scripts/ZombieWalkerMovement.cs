using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieWalkerMovement : MonoBehaviour
{ 
    public NavMeshAgent agent;
    public Transform playerTransform;
    
    private float maxTime = 0.5f;
    private Animator animator;
    private float distance;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f){
            agent.destination = playerTransform.position;
            timer = maxTime;
        }
        
        // muoviti verso il giocatore
        animator.SetFloat("Speed", agent.velocity.magnitude);

        distance = Vector3.Distance(playerTransform.position, transform.position);
        
        if(distance <= 1.6f){
            animator.SetBool("Attack", true);
        } else {
            animator.SetBool("Attack", false);
        }
    }
}
