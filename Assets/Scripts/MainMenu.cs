using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public AudioSource audioSrc;
    public AudioSource audioClick;

    public void StartPlay()
    {
        SceneManager.LoadScene("IdealHamburger");
    }

    public void PlayGame()
    {
        audioClick.Play();
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
}
