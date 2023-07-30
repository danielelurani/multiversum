using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{

    [SerializeField] private GameObject loadButton;
    private SaveManager sm;
    
    void Start(){

        sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();

        if(!PlayerPrefs.HasKey("CurrentScene"))
            loadButton.GetComponent<Button>().interactable = false;
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
        SceneManager.LoadScene("Tunnel");
    }

    public void LoadBoss()
    {
        Destroy(GameObject.Find("Music"));
        SceneManager.LoadScene("BossLevel");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

