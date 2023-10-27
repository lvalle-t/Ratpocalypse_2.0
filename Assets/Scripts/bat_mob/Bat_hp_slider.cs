using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class Bat_hp_slider : MonoBehaviour
{
    public Slider batSlider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(updater.batHp);
        fill.color = gradient.Evaluate(10);
    }

    // Update is called once per frame
    void Update()
    {
        float harm = updater.batHp;
        SetHealth(harm);
    }

    public void SetHealth(float health)
    {
        batSlider.value = health;
        fill.color = gradient.Evaluate(batSlider.value);
    }
}
