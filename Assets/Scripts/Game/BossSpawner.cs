using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    [SerializeField] private GameObject boss;


    private float tempoDiAttesa = 11f; 

    void Start()
    {
        Invoke("IstantiateBoss", tempoDiAttesa);
    }

    void IstantiateBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
