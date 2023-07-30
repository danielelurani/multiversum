using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    public GameObject main, options, cheats;

    public GameObject pauseFirstButton;
    public GameObject optionsClosedButton, optionsFirstButton;
    public GameObject cheatsFirstButton, cheatsClosedButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        { 
            if(!isGamePaused)
                PauseGame();
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenOptions(){

        options.SetActive(true);
        main.SetActive(false);
        cheats.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions(){

        options.SetActive(false);
        main.SetActive(true);
        cheats.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void OpenCheats(){

        options.SetActive(false);
        main.SetActive(false);
        cheats.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(cheatsFirstButton);
    }

    public void CloseCheats(){
        
        options.SetActive(false);
        main.SetActive(true);
        cheats.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(cheatsClosedButton);
    }
}
