using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimations : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void Walk(bool walk){
        animator.SetBool("Walk", walk);
    }

    public void Running(bool run){
        animator.SetBool("Running", run);
    }

    public void Attack1(){
        animator.SetTrigger("Attack1");
    }

    public void Attack2(){
        animator.SetTrigger("Attack2");
    }

    public void Jump(){
        animator.SetTrigger("Jump");
    }

    public void Damage(){
        animator.SetTrigger("Damage");
    }

    

    
}
