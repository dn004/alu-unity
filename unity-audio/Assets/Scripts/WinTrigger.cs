using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public TMP_Text timerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            timer.enabled = false;

            timerText.fontSize = 60;
            timerText.color = Color.green;

            timer.Win();
        }
    }
}
