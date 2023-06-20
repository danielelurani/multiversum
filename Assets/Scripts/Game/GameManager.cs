using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject wavesTimerTextObject;
    private Text wavesTimerText;

    private GameObject scoreTextObject;
    private Text scoreText;

    private EnemySpawner enemySpawner;

    public static int playerScore;
    public static int currentWave;
    public static int zombiesAlive;

    private bool waveCanStart;

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

        wavesTimerText = wavesTimerTextObject.GetComponent<Text>();
        scoreText = scoreTextObject.GetComponent<Text>();
        enemySpawner = GameObject.Find("ZombieSpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {

        // controlla se la nuova ondata può partire
        if(waveCanStart == true && zombiesAlive == 0 && currentWave <= 5){
            EnemySpawner.spawnCompleted = false;
            currentWave++;
            StartCoroutine(UpdateWavesTimerText());
            waveCanStart = false;
        }

        if(EnemySpawner.spawnCompleted){
            waveCanStart = true;
        }

        scoreText.text = "Score = " + playerScore;
            

        Debug.Log(zombiesAlive);
        Debug.Log(currentWave);
    }

    // attiva timer per inizio ondata
    private IEnumerator UpdateWavesTimerText(){

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
