using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour
{
    public GameObject levelUpUI;
    //public List<Button> upgradeButtons; // List of upgrade buttons

    private void Start()
    {
        // Disable the level-up UI initially

        // Subscribe to the upgrade button click events
        // foreach (Button button in upgradeButtons)
        // {
        //     button.onClick.AddListener(() => OnUpgradeButtonClick(button));
        // }
    }

    // private void OnUpgradeButtonClick(Button clickedButton)
    // {
    //     // Implement logic for handling the upgrade button click
    //     Debug.Log("Upgrade button clicked: " + clickedButton.name);

    //     // You can add more logic here based on the selected upgrade option
    //     // For example, apply upgrades to the player's stats or abilities
    // }

    public void ShowLevelUpScreen()
    {
        // Enable the level-up UI when called
        levelUpUI.SetActive(true);
    }

    public void HideLevelUpScreen()
    {
        // Disable the level-up UI when called
        levelUpUI.SetActive(false);
    }
}
