using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text finalTimeText;  // Reference to the FinalTime text on the WinCanvas
    public GameObject winCanvas;    // Reference to the WinCanvas

    private float elapsedTime = 0f;
    private bool isRunning = true;  // Added to control timer updates

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

    // Called when the player reaches the finish line (from WinTrigger)
    public void Win()
    {
        // Stop the timer
        isRunning = false;

        // Show final time on the WinCanvas
        winCanvas.SetActive(true);  // Activate the WinCanvas
        finalTimeText.text = timerText.text;  // Display the current timer text as the final time
    }
}
