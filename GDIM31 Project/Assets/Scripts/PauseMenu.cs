using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;


    public void TogglePauseMenu()
    {
        Debug.Log("TogglePauseMenu called");
        Debug.Log("Time.timeScale: " + Time.timeScale);

        if (pauseMenu.activeSelf)
        {
            // if pause menu is active, hide it and resume

            ResumeGame();
        }
        else
        {
            // if pause menu inactive, show and pause
            GameStateManager.TogglePause();
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        
        GameStateManager.TogglePause();
        pauseMenu.SetActive(false);

    }

    public void RestartLevel()
    {
        GameStateManager.TogglePause();
        GameStateManager.ResetScene();
    }

    public void GoToMainMenu()
    {
        GameStateManager.GameOver();
    }
}
