using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{
    public BossNavMesh BossNavMesh;

    public GameObject objectToThrow;
    private GameObject rock;
    public Transform throwSpawnPoint;
    public float throwForce = 10f;

    public float minThrowInterval = 2f;
    public float maxThrowInterval = 5f;

    private bool isThrowing = false;
    private GameObject player;
    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isThrowing)
        {
            rock.transform.position = throwSpawnPoint.position;
            rock.transform.rotation = throwSpawnPoint.rotation;
        }

        

    }

    public void InstantiateObject()
    {
        if (objectToThrow != null && throwSpawnPoint != null)
        {
            rock = Instantiate(objectToThrow, throwSpawnPoint.position, Quaternion.identity);
            rb = rock.GetComponent<Rigidbody>();
            rb.useGravity = false;
            isThrowing = true; 
        }
    }



    public void ThrowObject()
    {
        if (isThrowing)
        {
            Vector3 throwDirection = (player.transform.position - throwSpawnPoint.position).normalized;
            rb.useGravity = true;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            isThrowing = false;

            BossNavMesh.launchTimer = 0f;
            BossNavMesh.animator.SetBool("Throw", false);
            BossNavMesh.navMeshAgent.speed = 3.5f;
        }
    }
}
