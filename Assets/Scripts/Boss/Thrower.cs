using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    private GameObject rock;
    public RockScript rockScript;

    // Start is called before the first frame update
    void Start()
    {
        rockScript = GameObject.FindObjectOfType<RockScript>();
    }


    public void throwRock()
    {
        Debug.Log("Throwing");
        rockScript.ReleaseRock();
    }
}
