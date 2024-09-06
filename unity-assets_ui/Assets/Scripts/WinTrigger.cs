using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public TMP_Text timerText;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("player"))
        {
            // Stop the timer
            timer.enabled = false;

            // Change the text size and color
            timerText.fontSize = 60;
            timerText.color = Color.green;

            // Set flag to true to prevent multiple triggering
            //hasWon = true;
            timer.Win();
        }
    }
}
