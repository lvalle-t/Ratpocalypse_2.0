using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line


public class rat_healthbar : MonoBehaviour
{
public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    // = new Vector3(0f, 1.5f, 0f); // Example offset to place the health bar above the mob's head



    // Start is called before the first frame update
    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health<maxHealth);
        Slider.value= health;
        Slider.maxValue =maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color=Color.Lerp(Low,High,Slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        Slider.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position+Offset);
    }
}


// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class rat_healthbar : MonoBehaviour
// {
//     public Slider slider;

//     // Set the maximum health for the health bar
//     public void SetMaxHealth(int maxHealth)
//     {
//         slider.maxValue = maxHealth;
//         slider.value = maxHealth;
//     }

//     // Update the health bar with the current health
//     public void SetHealth(int currentHealth)
//     {
//         slider.value = currentHealth;
//     }
// }
