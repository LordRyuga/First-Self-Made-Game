using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas settings;
    public void StartGame()                 //Function to start game
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.None;
    }
    public void QuitGame()                  //Function to quit game
    {
        Application.Quit();
    }

    public void Vsync()                     //Function to turn V sync on and off when using a Toggle
    {
        if(QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void Settings()                  //Functions to enable and disable settings and home screen canvases.
    {
        settings.enabled = true;
        mainMenu.enabled = false;
    }
    public void MainMenu()
    {
        settings.enabled = false;
        mainMenu.enabled = true;
    }
}
