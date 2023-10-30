using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alligator_healthBar : MonoBehaviour
{
    public Slider alligatorSlider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(updater.alligatorHp);
        alligatorSlider.value = updater.alligatorHp;
        fill.color = gradient.Evaluate(updater.alligatorHp);
    }

    // Update is called once per frame
    void Update()
    {
        float harm = updater.alligatorHp;
        UpdateHealth(harm);
    }

    public void UpdateHealth(float health)
    {
        alligatorSlider.value = health;
        fill.color = gradient.Evaluate(alligatorSlider.value);
    }
}
