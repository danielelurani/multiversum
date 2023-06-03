using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZRHitBox : MonoBehaviour
{

    private ZRHealth health;

    void Start(){

        health = GetComponentInParent<ZRHealth>();
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
