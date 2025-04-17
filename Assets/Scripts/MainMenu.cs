using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void NewGame()
    {
        SceneManager.LoadScene("CuaDat");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

}
