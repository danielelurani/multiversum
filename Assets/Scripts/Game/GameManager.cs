using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject wavesTimerTextObject;
    private Text wavesTimerText;

    private GameObject scoreTextObject;
    private Text scoreText;

    private EnemySpawner enemySpawner;

    private GameObject rifle;
    public static Rifle rifleScript;

    private GameObject shotgun;
    public static Shotgun shotgunScript;

    private GameObject pistol;
    public static Pistol pistolScript;

    private GameObject saveManager;
    private SaveManager smScript;

    public static int playerScore;
    public static int currentWave;
    public static int zombiesAlive;

    public static bool waveCanStart;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        currentWave = 0;
        zombiesAlive = 0;
        waveCanStart = true;

        wavesTimerTextObject = GameObject.Find("WavesTimerText");
        wavesTimerTextObject.SetActive(false);

        scoreTextObject = GameObject.Find("Score");

        saveManager = GameObject.Find("SaveManager");
        smScript = saveManager.GetComponent<SaveManager>();

        wavesTimerText = wavesTimerTextObject.GetComponent<Text>();
        scoreText = scoreTextObject.GetComponent<Text>();
        enemySpawner = GameObject.Find("ZombieSpawner").GetComponent<EnemySpawner>();

        rifle = GameObject.Find("Rifle");
        rifleScript = rifle.GetComponent<Rifle>();

        shotgun = GameObject.Find("Shotgun");
        shotgunScript = shotgun.GetComponent<Shotgun>();

        pistol = GameObject.Find("Pistol");
        pistolScript = pistol.GetComponent<Pistol>();

        rifle.SetActive(false);
        shotgun.SetActive(false);

        //smScript.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.L)){
            smScript.LoadScene();
        }

        if (Input.GetKeyDown(KeyCode.S)){
            smScript.SaveData();
        }
        */
        // controlla se la nuova ondata può partire
        if(waveCanStart == true && zombiesAlive == 0 && currentWave <= 5){
            EnemySpawner.spawnCompleted = false;
            EnemySpawner.spawnedZombies = 0;
            currentWave++;
            StartCoroutine(UpdateWavesTimerText());
            waveCanStart = false;
        }

        if(EnemySpawner.spawnCompleted)
            waveCanStart = true;

        scoreText.text = "Score = " + playerScore;

        if(currentWave == 6)
            StartCoroutine(EndGame());
    }

    // attiva timer per inizio ondata
    private IEnumerator UpdateWavesTimerText(){

        if(currentWave <=5){
            for(int i = 10; i >= 0; i--){

                if(i == 1)
                {
                    yield return new WaitForSeconds(1f);            
                    wavesTimerText.text = "Inizio ondata " + currentWave + " in " + i + " secondo ...";
                    wavesTimerTextObject.SetActive(true);
                } else
                {
                    yield return new WaitForSeconds(1f);            
                    wavesTimerText.text = "Inizio ondata " + currentWave + " in " + i + " secondi ...";
                    wavesTimerTextObject.SetActive(true);
                }
            }

            wavesTimerTextObject.SetActive(false);
            enemySpawner.StartWave();
        }
    }

    private IEnumerator EndGame(){
        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LoadingLevelScene");
        
    }
}
