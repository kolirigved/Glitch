using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionpannel;
    public GameObject Mainmenu;
    void start()
    {
        instructionpannel.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
       public void ShowInstructions()
    {
        // Show the instructions panel
        instructionpannel.SetActive(true);
        Mainmenu.SetActive(false);
    }
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
}
