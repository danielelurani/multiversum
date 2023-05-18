using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform Player;
    Animator animator;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // muoviti verso il giocatore
        enemy.SetDestination(Player.position);
        animator.SetFloat("Speed", enemy.velocity.magnitude);

        distance = Vector3.Distance(Player.position, transform.position);
        if(distance <= 1.6f){
            animator.SetBool("Attack", true);
        } else {
            animator.SetBool("Attack", false);
        }

    }
}
