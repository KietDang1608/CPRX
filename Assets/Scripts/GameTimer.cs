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

    //void Awake()
    //{
    //    // Tự huỷ nếu đã tồn tại một GameTimer khác (tránh trùng nếu dùng DontDestroy)
    //    if (FindObjectsByType<GameTimer>(FindObjectsSortMode.None).Length > 1)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    DontDestroyOnLoad(gameObject);
    //}

}
