using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int currExp, maxExp, currLevel;
    private void OnEnable(){
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }
    private void OnDisable(){
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }
    private void HandleExperienceChange(int newExperience){
        currExp += newExperience;
        if(currExp >= maxExp){
            LevelUp();
        }
    }
    private void LevelUp(){
        // updater.maxHp += 3;
        if(updater.playerHp <= 9 && updater.playerHp <= updater.maxHp){
            updater.playerHp += 3;
            updater.playerHp = Mathf.Min(updater.playerHp, updater.maxHp);
        }
        
        Debug.Log("Leveled Up and HP increased");
        currLevel++;
        currExp = 0;
        maxExp +=100;
    }
}
