using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text bestTimeText;

    void Start()
    {
        ShowBestTime();
    }

    void ShowBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTimeOverall", -1f);

        if (bestTime >= 0f)
        {
            int minutes = Mathf.FloorToInt(bestTime / 60f);
            int seconds = Mathf.FloorToInt(bestTime % 60f);
            bestTimeText.text = $"Best Time: {minutes:00}:{seconds:00}";
        }
        else
        {
            bestTimeText.text = "Best Time: --:--";
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene("desert");
    }

    public void ExitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void Map2()
    {
        SceneManager.LoadScene("Map2"); 
    }

    public void Map3()
    {
        SceneManager.LoadScene("Map3");
    }

}
