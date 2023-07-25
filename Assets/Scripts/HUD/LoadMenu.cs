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
        Destroy(GameObject.Find("Music"));
        GameManager.isSaveLoaded = true;
        sm.LoadScene();
    }

    public void Load1()
    {
        Destroy(GameObject.Find("Music"));
        SceneManager.LoadScene("LevelOne");
    }

    public void Load2()
    {
        Destroy(GameObject.Find("Music"));
        SceneManager.LoadScene("LevelTwo");
    }

    public void Load3()
    {
        Destroy(GameObject.Find("Music"));
        SceneManager.LoadScene("LevelThree");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

