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

    public void NewGame()
    {
        SceneManager.LoadScene("CuaDat");
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
