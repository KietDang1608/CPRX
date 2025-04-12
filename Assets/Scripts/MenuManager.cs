using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static MenuManager Instance { get;  set; }
    public GameObject menuCanvas;
    public bool isMenuOpen;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !isMenuOpen)
        {
            isMenuOpen = true;
            menuCanvas.SetActive(isMenuOpen);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        } 
        else if (Input.GetKeyDown(KeyCode.M) && isMenuOpen)
        {
            isMenuOpen = false;
            menuCanvas.SetActive(isMenuOpen);
           
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
