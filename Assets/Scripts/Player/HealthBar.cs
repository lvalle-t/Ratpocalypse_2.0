using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider playerSlider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        playerSlider.value = updater.playerHp;
        fill.color = gradient.Evaluate(updater.playerHp);
        UpdateHealth(updater.playerHp);
    }

    // Update is called once per frame
    void Update()
    {
        float harm = updater.playerHp;
        UpdateHealth(harm);
    }

    public void UpdateHealth(float health)
    {
        playerSlider.value = health;
        fill.color = gradient.Evaluate(playerSlider.value);
    }
}
