using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    // public AudioSource buttonclick;
    public void RestartGame()
    {
        // buttonclick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void menu()
    {
        // buttonclick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
      public void QuitGame()
    {
        // buttonclick.Play();
        Application.Quit();
    }
}
