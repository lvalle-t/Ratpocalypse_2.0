using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XPBAr : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    public void UpdateXPBar(float currExperience, float gainedExperience, float maxExperienece){
        // slider.maxValue = maxExperienece;
        // slider.value = currExperience += maxExperienece;
        if(currExperience >= maxExperienece){
            Debug.Log("XP Bar reset");
            //ResetXpBar();
            slider.maxValue = maxExperienece;
        }

        // Ensure the new experience does not exceed the maximum experience
        //newExperience = Mathf.Min(newExperience, maxExperienece);
        

        //slider.minValue = 0;
        
        slider.value = gainedExperience + currExperience;
        Debug.Log("XP Bar increase");
    }
    public void ResetXpBar(){
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
