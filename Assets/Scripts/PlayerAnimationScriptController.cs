using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScriptController : MonoBehaviour
{

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isGoingForward = animator.GetBool("isGoingForward");
        bool isGoingLeft = animator.GetBool("isGoingLeft");
        bool isGoingRight = animator.GetBool("isGoingRight");
        bool isGoingBackward = animator.GetBool("isGoingBackward");

        // animazione senza armi per andare avanti
        if(Input.GetKey("w")){
            animator.SetBool("isGoingForward", true);

        } 
        
        if(!Input.GetKey("w")){

            animator.SetBool("isGoingForward", false);
        }

        // animazione senza armi per andare a sinistra
        if(Input.GetKey("a")){
            animator.SetBool("isGoingLeft", true);

        } 
        
        if(!Input.GetKey("a")){

            animator.SetBool("isGoingLeft", false);
        }

        // animazione senza armi per andare a destra
        if(Input.GetKey("d")){
            animator.SetBool("isGoingRight", true);

        } 
        
        if(!Input.GetKey("d")){

            animator.SetBool("isGoingRight", false);
        }

        // animazione senza armi per andare indietro
        if(Input.GetKey("s")){
            animator.SetBool("isGoingBackward", true);

        } 
        
        if(!Input.GetKey("s")){

            animator.SetBool("isGoingBackward", false);
        }
    }
}
