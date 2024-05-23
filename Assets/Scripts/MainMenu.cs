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
        Invoke("Play", 0.3f);
    }

    void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        click.Play();
        Invoke("Quit", 0.3f);
        Debug.Log("game Quit");
    }

    private void Quit()
    {
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
        instructionpannel.SetActive(false);
        Mainmenu.SetActive(true);
    }
}
