using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line


public class snake_healthbar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    // = new Vector3(0f, 1.5f, 0f); // Example offset to place the health bar above the mob's head



    // Start is called before the first frame update
    public void SetMaxHealth(float health)
    {
        // Slider.gameObject.SetActive(health < maxHealth);
        // Slider.value = health;
        // Slider.maxValue = maxHealth;

        // Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);

        Slider.maxValue = health;
        Slider.value = health;
    }

    public void SetHealth(float health)
    {
        Slider.value = health;
    }

    // Update is called once per frame
    //     void Update()
    //     {
    //         Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    //     }
}
