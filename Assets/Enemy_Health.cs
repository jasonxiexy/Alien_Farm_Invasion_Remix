using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
     public int maxHealth = 2;
    public int currentHealth =  2;
    public Health healthUI;
    

    void Start(){
        healthUI.setMax(maxHealth);
    }


    public void damage(){
        currentHealth -= 1;
            healthUI.setHealth(currentHealth);
            if(currentHealth == 0){
                //
            }
    }
}
