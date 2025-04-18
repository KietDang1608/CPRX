using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("CuaDat");
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
