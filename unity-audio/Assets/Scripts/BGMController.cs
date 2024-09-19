using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public string mainMenuSceneName = "MainMenu";

    void Start()
    {
        if (bgmAudioSource != null && !bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Play();
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == mainMenuSceneName)
        {
            StopBGM();
        }
    }

    public void StopBGM()
    {
        if (bgmAudioSource != null && bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Stop();
        }
        Destroy(gameObject);
    }

    public void OnWinFlagTouched()
    {
        StopBGM();
    }
}
