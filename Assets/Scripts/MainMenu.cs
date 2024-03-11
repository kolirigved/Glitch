using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionpannel;
    public GameObject Mainmenu;
    // [SerializeField] private AudioSource clickSondeffect;
    void start()
    {
        instructionpannel.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // clickSondeffect.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
        // clickSondeffect.Play();
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
        // clickSondeffect.Play();
    }
    public void ShowInstructions()
    {
        // Show the instructions panel
        instructionpannel.SetActive(true);
        Mainmenu.SetActive(false);
        // clickSondeffect.Play();
    }
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // clickSondeffect.Play();
    }
}
