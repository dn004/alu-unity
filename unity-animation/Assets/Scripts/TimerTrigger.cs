using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timer;
    
    void Start()
    {
        timer.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            timer.enabled = true;
            gameObject.SetActive(false);
        }
    }
}