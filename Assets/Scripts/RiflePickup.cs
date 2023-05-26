using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    public Rifle rifle;
    public Transform Player, MainCamera, SecondCamera;

    public float pickUpRange = 10f;

    void Update(){

        Vector3 distanceToPlayer = Player.position - transform.position;

        if(Input.GetKeyDown(KeyCode.E))
            PickUp();

    }

    private void PickUp(){

        transform.SetParent(SecondCamera);
        transform.localPosition = new Vector3(0.25f, -0.25f, 0.50f);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }
}
