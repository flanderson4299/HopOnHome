using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfx;

    public void PlayGame()
    {
        sfx.Play();
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void LeaveCredits()
    {
        SceneManager.LoadScene(0);
    }
}

