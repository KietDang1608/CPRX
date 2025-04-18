using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
}
