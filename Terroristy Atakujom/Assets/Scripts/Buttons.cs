using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public Image pauseMenu;

    public void NewGameButton(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
        Gun.EnemyHitCounter = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        PauseHandler.isPaused = !PauseHandler.isPaused;
        pauseMenu.gameObject.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Gun.EnemyHitCounter = 0;
        Time.timeScale = 1;
    }

    public void WonGameButton()
    {
        SceneManager.LoadScene("Victory");
        Gun.EnemyHitCounter = 0;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
