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
        }

    }
    private void LevelUp()
    {
        // updater.maxHp += 3;
        if (updater.playerHp <= 9 && updater.playerHp <= updater.maxHp)
        {
            updater.playerHp += 3;
            updater.playerHp = Mathf.Min(updater.playerHp, updater.maxHp);
        }

        Debug.Log("Leveled Up and HP increased");
        currLevel++;
        currExp = 0;
        maxExp += 100;
    }
}
