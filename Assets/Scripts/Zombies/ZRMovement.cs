using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZRMovement : MonoBehaviour
{ 
    private NavMeshAgent agent;
    private GameObject player;
    private Animator animator;
    
    private float maxTime = 0.5f;
    private float distance;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if(timer < 0.0f){
            agent.destination = player.transform.position;
            timer = maxTime;
        }
        
        // muoviti verso il giocatore
        animator.SetFloat("Speed", agent.velocity.magnitude);

        distance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 directionToTarget = player.transform.position - transform.position;
        directionToTarget.y = 0f;

        
        if(distance <= 2.3f){

            if(!animator.GetBool("isDead")){

                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            }
            
            animator.SetBool("Attack", true);
            
        } else {
            animator.SetBool("Attack", false);
        }
    }
}
