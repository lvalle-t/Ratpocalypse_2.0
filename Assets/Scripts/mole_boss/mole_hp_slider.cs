using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mole_hp_slider : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(updater.moleHp);

        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        float harm = updater.moleHp;
        SetHealth(harm);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.value);

    }
}
