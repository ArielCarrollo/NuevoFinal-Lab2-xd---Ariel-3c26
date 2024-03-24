using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarDespausar : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}


