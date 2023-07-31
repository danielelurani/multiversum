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
    [SerializeField] private GameObject spawnEffect;

    private GameObject wavesTimerTextObject;
    private Text wavesTimerText;

    private GameObject scoreTextObject;
    private Text scoreText;

    // boss level only variables
    private EnemySpawner enemySpawner;
    private BossLevelSpawner bossLevelSpawner;
    public static bool bossIsDeath;
    //---------------------------------------//

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
        if(SceneManager.GetActiveScene().name == "BossLevel"){

            gameScore = 3000;
            bossIsDeath = false;
            playerScore = gameScore;
            zombiesAlive = 0;
            waveCanStart = true;
            PauseMenu.isGamePaused = false;

            wavesTimerTextObject = GameObject.Find("WavesTimerText");
            wavesTimerTextObject.SetActive(false);

            scoreTextObject = GameObject.Find("Score");

            saveManager = GameObject.Find("SaveManager");
            smScript = saveManager.GetComponent<SaveManager>();
            smScript.SaveCurrentScene();

            wavesTimerText = wavesTimerTextObject.GetComponent<Text>();
            scoreText = scoreTextObject.GetComponent<Text>();
            bossLevelSpawner = GameObject.Find("EnemySpawner").GetComponent<BossLevelSpawner>();

            rifle = GameObject.Find("Rifle");
            rifleScript = rifle.GetComponent<Rifle>();

            shotgun = GameObject.Find("Shotgun");
            shotgunScript = shotgun.GetComponent<Shotgun>();

            pistol = GameObject.Find("Pistol");
            pistolScript = pistol.GetComponent<Pistol>();

            winCanvas.SetActive(false);
            rifle.SetActive(false);
            shotgun.SetActive(false);

        } else {

            playerScore = gameScore;
            currentWave = gameWave;
            zombiesAlive = 0;
            waveCanStart = true;
            PauseMenu.isGamePaused = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "BossLevel"){

            // controlla se la nuova ondata può partire
            if(waveCanStart == true){

                StartCoroutine(UpdateWavesTimerText());
                waveCanStart = false;
            }

            scoreText.text = "Score = " + playerScore;

            if(zombiesAlive == 0 && bossIsDeath == true)
                StartCoroutine(EndGame());

        } else {

            // controlla se la nuova ondata può partire
            if(waveCanStart == true && zombiesAlive == 0 && currentWave <= 5){
                EnemySpawner.spawnCompleted = false;
                EnemySpawner.spawnedZombies = 0;
                currentWave++;

                if(currentWave < 6)
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
    }

    // attiva timer per inizio ondata
    private IEnumerator UpdateWavesTimerText(){

        if(SceneManager.GetActiveScene().name == "BossLevel"){

            for(int i = 10; i >= 0; i--){

                if(i == 1)
                {
                    yield return new WaitForSeconds(1f);            
                    wavesTimerText.text = "Boss wave starts in " + i + " second ...";
                    wavesTimerTextObject.SetActive(true);
                    spawnEffect.SetActive(true);
                } else
                {
                    yield return new WaitForSeconds(1f);            
                    wavesTimerText.text = "Boss wave starts in " + i + " seconds ...";
                    wavesTimerTextObject.SetActive(true);
                }
            }

            wavesTimerTextObject.SetActive(false);
            bossLevelSpawner.StartWave();

        } else {

            if(currentWave <=5){
                for(int i = 10; i >= 0; i--){

                    if(i == 1)
                    {
                        yield return new WaitForSeconds(1f);            
                        wavesTimerText.text = "Wave " + currentWave + " starts in " + i + " second ...";
                        wavesTimerTextObject.SetActive(true);
                    } else
                    {
                        yield return new WaitForSeconds(1f);            
                        wavesTimerText.text = "Wave " + currentWave + " starts in " + i + " seconds ...";
                        wavesTimerTextObject.SetActive(true);
                    }
                }

                wavesTimerTextObject.SetActive(false);
                enemySpawner.StartWave();
            }
        }
    }

    private IEnumerator EndGame(){

        if(SceneManager.GetActiveScene().name == "BossLevel"){

            winCanvas.SetActive(true);
            winFadeImage = winCanvas.GetComponent<Image>();
            imageAlpha = winFadeImage.color;

            while(imageAlpha.a <= 2){

                yield return new WaitForSeconds(1f);
                imageAlpha.a = imageAlpha.a + 0.001f;
                winFadeImage.color = imageAlpha;
            }

            SceneManager.LoadScene("WinScene");

        } else {

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
}
