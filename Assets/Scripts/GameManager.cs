using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject wavesTimerTextObject;
    private Text wavesTimerText;

    public static int playerScore;
    public static int currentWave;
    public static int zombiesAlive;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        currentWave = 1;
        zombiesAlive = 0;

        wavesTimerTextObject = GameObject.Find("WavesTimerText");
        wavesTimerTextObject.SetActive(false);

        wavesTimerText = wavesTimerTextObject.GetComponent<Text>();

        StartCoroutine(UpdateWavesTimerText());

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zombiesAlive);
    }

    private IEnumerator UpdateWavesTimerText(){



        wavesTimerTextObject.SetActive(true);

        for(int i = 9; i >= 0; i--){

            yield return new WaitForSeconds(1f);
            wavesTimerText.text = "Inizio ondata " + currentWave + " in " + i + " secondi ...";
        }

        wavesTimerTextObject.SetActive(false);
    }
}
