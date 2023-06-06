using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void Load1()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Load2()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void Load3()
    {
        SceneManager.LoadScene("");
    }

    public void Back()
    {

        SceneManager.LoadScene("MainMenu");
    }
}

