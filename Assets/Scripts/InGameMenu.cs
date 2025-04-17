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
