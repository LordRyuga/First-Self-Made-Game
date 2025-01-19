using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public Canvas PauseScreenCanvas;
    public Canvas SettingsCanvas;
    public gameManager player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseScreenCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Time.timeScale = 0f;
            PauseScreenCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Time.timeScale = 1f;
            PauseScreenCanvas.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("check");
        }
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        PauseScreenCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Quit()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
    public void Save()
    {
        SaveSystem.SavePlayer(player);
    }

    public void Settings()
    {
        SettingsCanvas.enabled = true;
        PauseScreenCanvas.enabled = false;
    }

    public void Pause()
    {
        PauseScreenCanvas.enabled = true;
        SettingsCanvas.enabled = false;
    }
}
