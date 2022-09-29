using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseMenuUI;
    public FirstPersonController FPCscript;

    // Update is called once per frame
    void Update()
    {
        if(!paused)
        {
            FPCscript.ToggleCursor(true);
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FPCscript.ChangeSensitivity(2f, 2f);
        FPCscript.ToggleCursor(true);
        paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FPCscript.ChangeSensitivity(0f, 0f);
        FPCscript.ToggleCursor(false);
        paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
