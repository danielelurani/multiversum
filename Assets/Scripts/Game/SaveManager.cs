using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private GameObject player, gameManager;
    private Pistol pistol;
    private Rifle rifle;
    private Shotgun shotgun;
    private EquippingScript equip;
    private CharacterStats playerStats;
    private GameManager gmScript;
    
    private string currentScene;
    private int playerHealth;
    private int playerScore;
    private int waveToStart;
    private bool weaponEquippedATM;
    private bool isPistolEquipped;
    private bool isRifleEquipped;
    private bool isShotgunEquipped;
    private bool pistolAmmo;
    private bool rifleAmmo;
    private bool shotgunAmmo;

    public void SaveData(){

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");

        pistol = player.GetComponentInChildren<Pistol>(true);
        rifle = player.GetComponentInChildren<Rifle>(true);
        shotgun = player.GetComponentInChildren<Shotgun>(true);
        equip = player.GetComponent<EquippingScript>();
        playerStats = player.GetComponent<CharacterStats>();
        gmScript = gameManager.GetComponent<GameManager>();

        currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentScene", currentScene);

        PlayerPrefs.SetInt("PlayerHealth", playerStats.health);

        PlayerPrefs.SetInt("PlayerScore", GameManager.playerScore);

        PlayerPrefs.SetInt("Wave", GameManager.currentWave);

        PlayerPrefs.SetInt("WeaponEquippedATM", equip.slotEquippedATM);

        if(equip.isSlot1Active){
            PlayerPrefs.SetInt("Slot1", 1);
            PlayerPrefs.SetInt("PistolAmmo", pistol.currentAmmo);
        } else {
            PlayerPrefs.SetInt("Slot1", 0);
            PlayerPrefs.SetInt("PistolAmmo", pistol.currentAmmo);
        }

        if(equip.isSlot2Active){
            PlayerPrefs.SetInt("Slot2", 1);
            PlayerPrefs.SetInt("RifleAmmo", rifle.currentAmmo);
        } else {
            PlayerPrefs.SetInt("Slot2", 0);
            PlayerPrefs.SetInt("RifleAmmo", rifle.currentAmmo);
        }

        if(equip.isSlot3Active){
            PlayerPrefs.SetInt("Slot3", 1);
            PlayerPrefs.SetInt("ShotgunAmmo", shotgun.currentAmmo);
        } else {
            PlayerPrefs.SetInt("Slot3", 0);
            PlayerPrefs.SetInt("ShotgunAmmo", shotgun.currentAmmo);
        }

        Debug.Log("salvato");
        Debug.Log("player score " + PlayerPrefs.GetInt("PlayerScore"));
    }

    public void LoadScene(){
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }

    public void LoadData(){

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");

        pistol = player.GetComponentInChildren<Pistol>(true);
        rifle = player.GetComponentInChildren<Rifle>(true);
        shotgun = player.GetComponentInChildren<Shotgun>(true);
        equip = player.GetComponent<EquippingScript>();
        playerStats = player.GetComponent<CharacterStats>();
        gmScript = gameManager.GetComponent<GameManager>();

        
        playerStats.health = PlayerPrefs.GetInt("PlayerHealth");
        GameManager.playerScore = PlayerPrefs.GetInt("PlayerScore");
        GameManager.currentWave = PlayerPrefs.GetInt("Wave");
        equip.slotEquippedATM = PlayerPrefs.GetInt("WeaponEquippedATM");

        if(PlayerPrefs.GetInt("Slot1") == 1)
            equip.isSlot1Active = true;
        else
            equip.isSlot1Active = false;

        if(PlayerPrefs.GetInt("Slot2") == 1)
            equip.isSlot2Active = true;
        else
            equip.isSlot2Active = false;

        if(PlayerPrefs.GetInt("Slot3") == 1)
            equip.isSlot3Active = true;
        else
            equip.isSlot3Active = false;

        pistol.currentAmmo = PlayerPrefs.GetInt("PistolAmmo");
        rifle.currentAmmo = PlayerPrefs.GetInt("RifleAmmo");
        shotgun.currentAmmo = PlayerPrefs.GetInt("ShotgunAmmo");
    }
}
