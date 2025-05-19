using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToload;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToload); 
    }

    public void LoadCreditsScene() 
    {
        SceneManager.LoadScene("Credits");
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }
}
