using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{

    private SaveManager sm;

    void Start(){

        sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void LoadSave()
    {
        GameManager.isSaveLoaded = true;
        sm.LoadScene();
    }

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
        SceneManager.LoadScene("LevelThree");
    }

    public void Back()
    {

        SceneManager.LoadScene("MainMenu");
    }
}

