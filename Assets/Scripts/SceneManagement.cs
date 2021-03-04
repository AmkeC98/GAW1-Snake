using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public float delayTime = 2f;
    public AudioSource backgroundAudio;
    public AudioSource buttonAudio;

    public void StartGame()
    {
        backgroundAudio.Stop();
        buttonAudio.Play();
        Invoke("DelayedAction", delayTime);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void OpenMenu()
    {
        Debug.Log("Go to main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void DelayedAction()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene("GameScene");
    }
}
