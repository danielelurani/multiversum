using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevelMenu : MonoBehaviour
{

   

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToNextLevel()
    {
        string currentScene = PlayerPrefs.GetString("CurrentScene");
        SceneManager.LoadScene(currentScene + 1);
    }
}
