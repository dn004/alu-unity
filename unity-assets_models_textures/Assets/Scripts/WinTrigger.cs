using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script
    public TMP_Text timerText; // Reference to the text to display when player wins

    //private bool hasWon = false; // Flag to track if the player has already won

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the WinFlag collider and hasn't already won
        if (other.CompareTag("player"))
        {
            // Stop the timer
            timer.enabled = false;

            // Change the text size and color
            timerText.fontSize = 60;
            timerText.color = Color.green;

            // Set flag to true to prevent multiple triggering
            //hasWon = true;
        }
    }
}
