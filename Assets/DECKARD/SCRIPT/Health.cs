using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   public Slider slider;
   public Gradient gradient;
   public Image fill;//set the fill image to this collor
    // Start is called before the first frame update
    public void setHealth(int health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    public void setMax(int health){
        slider.maxValue = health;
        slider.value = health;
        gradient.Evaluate(1f);
        
        fill.color = gradient.Evaluate(1f);
    
    } 
}
