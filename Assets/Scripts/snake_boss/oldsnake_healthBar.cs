using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snake_healthBar : MonoBehaviour
{
    public Slider snakeSlider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(updater.snakeHp);
        snakeSlider.value = updater.snakeHp;
        fill.color = gradient.Evaluate(updater.snakeHp);
    }

    // Update is called once per frame
    void Update()
    {
        float harm = updater.snakeHp;
        UpdateHealth(harm);
    }

    public void UpdateHealth(float health)
    {
        snakeSlider.value = health;
        fill.color = gradient.Evaluate(snakeSlider.value);
    }
}
