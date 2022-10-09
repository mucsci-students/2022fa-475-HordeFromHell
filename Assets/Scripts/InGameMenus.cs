using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class InGameMenus : MonoBehaviour
{
    public bool paused = false;
    public bool dead = false;

    public GameObject pauseMenuUI;
    public GameObject deathMenuUI;
    public FirstPersonController FPCScript;

    // Update is called once per frame
    void Update()
    {
        if(!paused && !dead)
        {
            FPCScript.ToggleCursor(true);
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
        FPCScript.ChangeSensitivity(2f, 2f);
        FPCScript.ToggleCursor(true);
        paused = false;
    }

    public void Restart()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FPCScript.ToggleCursor(true);
        FPCScript.GetComponent<Score>().score = 0;
        dead = false;
        SceneManager.LoadScene("Forest");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FPCScript.ChangeSensitivity(0f, 0f);
        FPCScript.ToggleCursor(false);
        paused = true;
    }

    public void Die()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FPCScript.ChangeSensitivity(0f, 0f);
        FPCScript.ToggleCursor(false);
        dead = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        FPCScript.GetComponent<Score>().score = 0;
        SceneManager.LoadScene("Menu");
    }
}
