using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public TMP_Text bestTimeText;
    public void NewGame()
    {
        SceneManager.LoadScene("CuaDat");
    }
        
    void Start()
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


    public void ExitGame()
    {
        Debug.Log("quitting");
        SceneManager.LoadScene("MainMenu");
        Application.Quit();
    }

    public void Map2()
    {
        SceneManager.LoadScene("DarkForest");
    }

    public void Map3()
    {
        SceneManager.LoadScene("desert");
    }
    public void Map4()
    {
        SceneManager.LoadScene("CuaHuu");
    }

}
