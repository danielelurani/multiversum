using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private int gameScore = 0;
    [SerializeField] private int gameWave = 0;

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

    private Image winFadeImage;
    Color imageAlpha;

    public static int playerScore;
    public static int currentWave;
    public static int zombiesAlive;

    public static bool waveCanStart;
    public static bool isSaveLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = gameScore;
        currentWave = gameWave;
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

        winCanvas.SetActive(false);
        rifle.SetActive(false);
        shotgun.SetActive(false);

        if(isSaveLoaded){
            smScript.LoadData();
            isSaveLoaded = false;
            currentWave --;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // controlla se la nuova ondata può partire
        if(waveCanStart == true && zombiesAlive == 0 && currentWave <= 5){
            EnemySpawner.spawnCompleted = false;
            EnemySpawner.spawnedZombies = 0;
            currentWave++;

            if(currentWave !=1)
                smScript.SaveData();

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

        winCanvas.SetActive(true);
        winFadeImage = winCanvas.GetComponent<Image>();
        imageAlpha = winFadeImage.color;

        while(imageAlpha.a <= 5){

            yield return new WaitForSeconds(1f);
            imageAlpha.a = imageAlpha.a + 0.001f;
            winFadeImage.color = imageAlpha;
        }

        SceneManager.LoadScene("LoadingLevelScene");
    }
}
