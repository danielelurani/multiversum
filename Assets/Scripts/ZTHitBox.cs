using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTHitBox : MonoBehaviour
{

    private ZTHealth health;

    void Start(){

        health = GetComponentInParent<ZTHealth>();
    }

    public void OnRaycastHitP(Pistol pistol){
        health.TakeDamage(pistol.GetDamageValue());
    }

    public void OnRaycastHitR(Rifle rifle){
        health.TakeDamage(rifle.GetDamageValue());
    }

    public void OnRaycastHitS(Shotgun shotgun){
        health.TakeDamage(shotgun.GetDamageValue());
    }
}