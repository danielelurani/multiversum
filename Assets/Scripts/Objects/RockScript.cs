using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    [SerializeField]
    private Transform parentBone;
    [SerializeField]
    private  Rigidbody rigid;
    [SerializeField]
    private float force = 2000;

    // Start is called before the first frame update
    void Start()
    {
        parentBone = GetComponentInParent<Transform>();
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReleaseRock()
    {
        transform.parent = null;
        rigid.useGravity = true;
        transform.rotation = parentBone.transform.rotation;
        rigid.AddForce(transform.forward * force);
    }
}
