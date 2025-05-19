using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryMenu : MonoBehaviour
{

    public string Game_Scene;
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Game_Scene);
    }
}