using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XPBAr : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    //[SerializeField] LevelProgression lp;
    public void Awake()
    {
        slider.minValue = 0;
        slider.maxValue = updater.maxExp;
    }
    public void UpdateXPBar(int currExperience, int gainedExperience, int maxExperienece)
    {
        slider.value = currExperience;
        //Debug.Log("XP Bar increase");
    }
    public void ResetXpBar()
    {
        slider.value = 0;
        slider.minValue = 0;
        slider.maxValue = updater.maxExp;
    }
}
