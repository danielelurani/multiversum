using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWHitBox : MonoBehaviour
{

    public ZombieWalkerHealth health;

    public void OnRaycastHit(Pistol pistol){
        health.TakeDamage(pistol.damage);
    }
}
