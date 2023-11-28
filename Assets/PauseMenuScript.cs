using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;
    public GameObject catPlayer;
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MAINMENU!!!!!");
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            catPlayer.SetActive(false);
            Time.timeScale = 0;
        }

    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        catPlayer.SetActive(true);
        Time.timeScale = 1;
    }
}
