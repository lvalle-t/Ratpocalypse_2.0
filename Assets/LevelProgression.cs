using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int currExp, maxExp, currLevel;
    public int MaxExp => maxExp;
    public int CurrLevel => currLevel;
    [SerializeField] XPBAr xpBar;
    public GameObject upScreen;
    public GameObject catPlayer;
    [SerializeField] cat_movement catMovement;
    private void Awake()
    {
        xpBar = GetComponentInChildren<XPBAr>();
    }
    private void OnEnable()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }
    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }
    private void HandleExperienceChange(int newExperience)
    {
        currExp += newExperience;
        xpBar.UpdateXPBar(currExp, newExperience, maxExp);
        if (currExp >= maxExp)
        {
            LevelUp();
            xpBar.ResetXpBar();
            //upScreen.SetActive(false);
        }

    }
    private void LevelUp()
    {
        // updater.maxHp += 3;
        // if (updater.playerHp <= 9 && updater.playerHp <= updater.maxHp)
        // {
        //     updater.playerHp += 3;
        //     updater.playerHp = Mathf.Min(updater.playerHp, updater.maxHp);
        // }
        upScreen.SetActive(true);
        catPlayer.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Leveled Up");
        currLevel++;
        currExp = 0;
        maxExp += 100;
    }
    public void HealthIncrease(){
        if (updater.playerHp <= 9 && updater.playerHp <= updater.maxHp)
        {
            updater.playerHp += 1.5f;
            updater.playerHp = Mathf.Min(updater.playerHp, updater.maxHp);
        }
        upScreen.SetActive(false);
        catPlayer.SetActive(true);
        Time.timeScale = 1;
    }
    public void SpeedIncrease(){
        catMovement = GetComponent<cat_movement>();
        catMovement.speed += 1f;
        upScreen.SetActive(false);
        catPlayer.SetActive(true);
        Time.timeScale = 1;
    }
}
