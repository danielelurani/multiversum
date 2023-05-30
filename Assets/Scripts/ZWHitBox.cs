using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWHitBox : MonoBehaviour
{
    public ZombieWalkerHealth health;

    public void OnRaycastHitP(Pistol pistol){
        health.TakeDamage(pistol.damage);
    }

    public void OnRaycastHitR(Rifle rifle){
        health.TakeDamage(rifle.GetDamageValue());
    }

    public void OnRaycastHitS(Shotgun shotgun){
        health.TakeDamage(shotgun.damage);
    }
}
