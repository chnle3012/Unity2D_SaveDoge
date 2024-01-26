using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public static bool isClick = false;
    [SerializeField] private GameObject pausePanel;
    public void Play()
    {
        SceneManager.LoadScene("Game");
        isClick = false;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        isClick = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        isClick = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
