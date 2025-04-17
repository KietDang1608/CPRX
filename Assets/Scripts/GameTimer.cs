using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText; // Gán cái Text UI từ Inspector
    private float timer = 0f;
    private bool isRunning = true;

    void Start()
    {
        timer = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float StopTimer()
    {
        isRunning = false;
        return timer;
    }
}
