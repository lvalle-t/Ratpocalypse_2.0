using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Debug.Log("GAMEOVERSCREENON!!!!!");
    }

    public void restart()
    {
        SceneManager.LoadScene("Laboratory");
        updater.playerHp = 9f;
        updater.treatCount = 0;
        updater.alligatorHp = 60f;
        updater.antHp = 1f;
        updater.batHp = 1f;
        updater.moleHp = 40f;
        updater.ratHp = 1f;
        updater.snakeHp = 1f;
        Debug.Log("RESTART!!!!!");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MAINMENU!!!!!");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("QUITTT!!!!!");
    }
}
