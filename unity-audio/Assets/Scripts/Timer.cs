using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text finalTimeText; 
    public GameObject winCanvas;
    public AudioSource winSound;
    public BGMController bgmController; 

    private float elapsedTime = 0f;
    private bool isRunning = true;  
    private bool hasPlayedWinSound = false;  

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime * 100) % 100;

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void Win()
    {
        isRunning = false;

        winCanvas.SetActive(true);  
        finalTimeText.text = timerText.text;

        if (bgmController != null)
        {
            bgmController.StopBGM();
        }

        if (!hasPlayedWinSound)
        {
            if (winSound != null)
            {
                winSound.Play();
            }
            hasPlayedWinSound = true;
        }
    }
}
