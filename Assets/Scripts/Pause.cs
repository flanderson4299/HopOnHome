using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfx;
    [SerializeField]
    private GameObject pauseMenu;

    public void Resume()
    {
        sfx.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {   
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        sfx.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
