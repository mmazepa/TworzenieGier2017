using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour {

    public static bool isPaused = false;
    public Image pauseMenu;

    private void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = 0;
            if (isPaused) {
                Time.timeScale = 0;
                pauseMenu.gameObject.SetActive(true);
            } else
            {
                Time.timeScale = 1;
                pauseMenu.gameObject.SetActive(false);
            }
        }
	}
}
