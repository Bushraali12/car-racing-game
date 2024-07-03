using UnityEngine;

public class stoptimer : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script
    private float resumeDelay = 1.0f; // Delay in seconds before resuming the timer

    private bool isTimerPaused = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Opponent")) && !isTimerPaused)
        {
            timer.StopTimerForSeconds(resumeDelay); // Stop the timer for 1 second
            isTimerPaused = true;
        }
    }
}

