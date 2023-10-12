// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class HealthBar : MonoBehaviour
// {
//     public Slider slider;
   
//     public void SetMaxHealth(int health){
//         slider.maxHealth=health;
//         slider.value=health;
//     }

//     public void SetHealth(int health){
//         slider.value=health;
//     }
// }


// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // Set the maximum health for the health bar
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    // Update the health bar with the current health
    public void SetHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
