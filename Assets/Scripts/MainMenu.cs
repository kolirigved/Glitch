using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionpannel;
    public GameObject Mainmenu;
    public AudioSource click;
    void start()
    {
        instructionpannel.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void PlayGame()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }

    public void SettingsMenu()
    {
        click.Play();
        SceneManager.LoadScene("SettingsMenu");
    }
    public void ShowInstructions()
    {
        // Show the instructions panel
        click.Play();
        instructionpannel.SetActive(true);
        Mainmenu.SetActive(false);
    }
    public void back()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
