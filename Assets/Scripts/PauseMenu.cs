using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool paused;
    [SerializeField] GameObject pauseUI;

    public static PauseMenu Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Resume();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9)) && !paused)
            Pause();
    }

    void Pause()
    {
        paused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        paused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}