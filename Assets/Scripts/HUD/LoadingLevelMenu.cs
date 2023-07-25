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

        if(currentScene == "LevelOne")
            SceneManager.LoadScene("LevelTwo");

        if(currentScene == "LevelTwo")
            SceneManager.LoadScene("Tunnel");

        if(currentScene == "Tunnel")
            SceneManager.LoadScene("BossLevel");
    }
}
