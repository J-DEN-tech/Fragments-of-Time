using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public AudioSource soundPlayer;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void playAudio()
    {
        soundPlayer.Play();
    }

    /*public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    */
    public void PauseGame()
    {
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
