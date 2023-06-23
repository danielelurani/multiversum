using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombieWalker;
    [SerializeField] private GameObject zombieRunner;
    [SerializeField] private GameObject zombieTank;
    [SerializeField] private float interval = 0.5f;

    private int random = 1;
    private GameObject spwn1;
    private GameObject spwn2;
    private GameObject spwn3;
    private GameObject spwn4;

    private int baseZombieWalkerCount = 5;
    private int baseZombieRunnerCount = 2;
    private int baseZombieTankCount = 1;

    private int zombiesToSpawn;
    public static int spawnedZombies;

    public static int zombieWalkerCount = 0;
    public static int zombieRunnerCount = 0;
    public static int zombieTankCount = 0;
    
    public static bool spawnCompleted;

    // Start is called before the first frame update
    void Start()
    {
        // trova gli spawn
        spwn1 = GameObject.Find("Spawn1");
        spwn2 = GameObject.Find("Spawn2");
        spwn3 = GameObject.Find("Spawn3");
        spwn4 = GameObject.Find("Spawn4");

        // carica gli assets necessari per gli zombie
        zombieWalker = Resources.Load<GameObject>("Prefabs/ZombieWalker");
        zombieRunner = Resources.Load<GameObject>("Prefabs/ZombieRunner");
        zombieTank = Resources.Load<GameObject>("Prefabs/ZombieTank");

        spawnCompleted = false;
        zombiesToSpawn = 0;
        spawnedZombies = 0;

    }

    void Update() {
        random = Random.Range(1,5);

        zombiesToSpawn = (baseZombieWalkerCount * GameManager.currentWave) + (baseZombieRunnerCount * GameManager.currentWave)+ (baseZombieTankCount *     GameManager.currentWave);

        if(spawnedZombies >= zombiesToSpawn && !spawnCompleted)
            spawnCompleted = true;
        

        Debug.Log("Zombie Spawnati " + spawnedZombies);
        Debug.Log("Zombies Alive " + GameManager.zombiesAlive);
        Debug.Log("Spawn completed ? " + spawnCompleted);
            
    }

    public void StartWave(){

        StartCoroutine(spawnZW(interval, zombieWalker));
        StartCoroutine(spawnZR(interval, zombieRunner));
        StartCoroutine(spawnZT(interval, zombieTank));
    }

    private IEnumerator spawnZW(float interval, GameObject enemyType){

        while(zombieWalkerCount < baseZombieWalkerCount * GameManager.currentWave){

            yield return new WaitForSeconds(interval);

            if(random == 1){
                GameObject newEnemy = Instantiate(enemyType, spwn1.transform.position, Quaternion.identity);
            }
                
            if(random == 2){
                GameObject newEnemy = Instantiate(enemyType, spwn2.transform.position, Quaternion.identity);
            }

            if(random == 3){
                GameObject newEnemy = Instantiate(enemyType, spwn3.transform.position, Quaternion.identity);
            }

            if(random == 4){
                GameObject newEnemy = Instantiate(enemyType, spwn4.transform.position, Quaternion.identity);
            }
                
            spawnedZombies++;
            zombieWalkerCount ++;
            GameManager.zombiesAlive ++;
        }
    }

    private IEnumerator spawnZR(float interval, GameObject enemyType){

        while(zombieRunnerCount < baseZombieRunnerCount * GameManager.currentWave){

            yield return new WaitForSeconds(interval);

            if(random == 1){
                GameObject newEnemy = Instantiate(enemyType, spwn1.transform.position, Quaternion.identity);
            }
                
            if(random == 2){
                GameObject newEnemy = Instantiate(enemyType, spwn2.transform.position, Quaternion.identity);
            }

            if(random == 3){
                GameObject newEnemy = Instantiate(enemyType, spwn3.transform.position, Quaternion.identity);
            }

            if(random == 4){
                GameObject newEnemy = Instantiate(enemyType, spwn4.transform.position, Quaternion.identity);
            }

            spawnedZombies++;
            zombieRunnerCount ++;
            GameManager.zombiesAlive ++;
        }
    }

    private IEnumerator spawnZT(float interval, GameObject enemyType){

        while(zombieTankCount < baseZombieTankCount * GameManager.currentWave){

            yield return new WaitForSeconds(interval);
            
            if(random == 1){
                GameObject newEnemy = Instantiate(enemyType, spwn1.transform.position, Quaternion.identity);
            }
                
            if(random == 2){
                GameObject newEnemy = Instantiate(enemyType, spwn2.transform.position, Quaternion.identity);
            }

            if(random == 3){
                GameObject newEnemy = Instantiate(enemyType, spwn3.transform.position, Quaternion.identity);
            }

            if(random == 4){
                GameObject newEnemy = Instantiate(enemyType, spwn4.transform.position, Quaternion.identity);
            }

            spawnedZombies++;
            zombieTankCount ++;
            GameManager.zombiesAlive ++;
        }
    }
}
