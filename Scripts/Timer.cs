using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private float initialTime = 400.0f;
    private float currentTime;
    private bool isRunning = true;
    private DateTime startTime; // Store the start time

    private void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("Timer: TimerText reference is not set. Please assign a Text component to TimerText in the Inspector.");
            enabled = false;
            return;
        }

        currentTime = initialTime;
        UpdateTimerText();
        startTime = DateTime.Now; // Record the start time
    }

    private void Update()
    {
        if (isRunning)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            currentTime = initialTime - (float)elapsedTime.TotalSeconds;
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
            }
            UpdateTimerText();
        }
    }

    public void StopTimerForSeconds(float seconds)
    {
        if (isRunning)
        {
            isRunning = false;
            StartCoroutine(ResumeAfterDelay(seconds));
        }
    }

    private System.Collections.IEnumerator ResumeAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isRunning = true; // Resume the timer
        startTime = DateTime.Now - TimeSpan.FromSeconds(currentTime); // Adjust the start time
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }
}

