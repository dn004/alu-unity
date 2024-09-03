using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    private float elapsedTime = 0f;

    void Update()
    {
       
        elapsedTime += Time.deltaTime;
        UpdateTimerUI();
    }
    

    void UpdateTimerUI()
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime * 100) % 100;

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

}
