using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line


public class spider_healthbar : MonoBehaviour
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
        if (Slider != null && Camera.main != null){

            Slider.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position+Offset);
        }
    }
}