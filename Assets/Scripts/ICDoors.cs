using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICDoors : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ZombieHitbox"))
            animator.SetBool("isNear", true);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("ZombieHitbox"))
            animator.SetBool("isNear", true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("ZombieHitbox")){
            animator.SetBool("isNear", false);
        }
    }
}
