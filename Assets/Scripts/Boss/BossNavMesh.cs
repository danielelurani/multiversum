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
    private float interval = 1f;

  
    
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

        if (distance <= 2.0f)
        {
            AttackPlayer();
        }
        else
            animator.SetBool("Attack", false);

        
        if(animator.GetBool("SecondPhase")) { 
            StartCoroutine(SecondPhaseAttack());
           }
        
        /*
        if(distance >= 10f)
            ThrowObject();
        else
            animator.SetBool("Throw", false);
            */

    }

    private IEnumerator SecondPhaseAttack()
    {

        while (animator.GetBool("SecondPhase")) {

            ThrowObject();

            /*
            AnimationClip clip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            float durataAnimazione = clip.length;
            
            yield return new WaitForSeconds(durataAnimazione);

            
            animator.SetBool("Throw", false);
            */

            yield return new WaitForSeconds(interval);

            

        }




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

        if (!animator.GetBool("isDead"))
        {

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);

            animator.SetBool("Throw", true);
        }

       
    }

}

