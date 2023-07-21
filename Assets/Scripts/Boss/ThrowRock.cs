using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{

    public GameObject objectToThrow;
    private GameObject rock;
    public Transform throwSpawnPoint;
    public float throwForce = 10f;
  
    private bool isThrowing;
    private GameObject player;
    private Rigidbody rb;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    /*
    private void FixedUpdate()
    {
        RaycastHit hitPoint;
       bool raycastRes = Physics.Raycast(transform.position, transform.forward, out hitPoint, Mathf.Infinity);

        if (raycastRes)
        {
            Debug.Log("Collision")
        }
    }
    */

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
        }
    }
}
