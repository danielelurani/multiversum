using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    [SerializeField] private int damage = 90;
    [SerializeField] private float collisionRadius = 0.3f;

    private GameObject player;
    private CharacterStats playerStats;

    private Animator animator;
    private bool collisionProcessed = false;

    public float shiftDistance = 2f; 
    public float shiftDuration = 0.5f;
    public Vector3 shiftDirection = Vector3.back;
    private float shiftTimer = 0f;
    private bool isShifted;

    void Start()
    {

        // prendo l'oggetto player e il suo componente CharacterStats per poi usarlo nella funzione OnTriggerEnter
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {

        if (!collisionProcessed && animator.GetBool("Attack") && CheckCollision(transform.position, player.transform.position, collisionRadius))
        {
            playerStats.TakeDamage(damage);
            collisionProcessed = true;
            StartCoroutine(WaitForNextAttack());
            ShiftBack();
           
        }
    }

    bool CheckCollision(Vector3 thisObjPosition, Vector3 otherObjPosition, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(thisObjPosition, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == player)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator WaitForNextAttack()
    {

        yield return new WaitForSeconds(1f);
        collisionProcessed = false;
    }

    private void ShiftBack()
    {
        shiftTimer = shiftDuration; 
        shiftTimer -= Time.deltaTime;

        Vector3 knockbackVector = shiftDirection * shiftDistance * (shiftTimer/ shiftDuration);

        player.transform.position += knockbackVector;
    }
}
