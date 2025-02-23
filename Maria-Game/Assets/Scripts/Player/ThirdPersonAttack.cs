using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonAtack : MonoBehaviour {

     public ThirdPersonAnimations animations;

    public float AttackRate = 2f;
    float nextAttackTime = 0f;


    void Awake()
    {
        animations = GetComponent<ThirdPersonAnimations>();
    }


    void Update()
    {
       if(Time.time >= nextAttackTime){
        if(Input.GetKeyDown(KeyCode.J)){
            animations.Attack1();
        }

        if(Input.GetKeyDown(KeyCode.K)){
            animations.Attack2();
        }

        nextAttackTime = Time.time + 1f / AttackRate;

        
       }

    }

    

    


   
    
}