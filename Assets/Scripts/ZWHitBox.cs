using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWHitBox : MonoBehaviour
{

    private ZWHealth health;

    void Start(){

        health = GetComponentInParent<ZWHealth>();
    }

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
