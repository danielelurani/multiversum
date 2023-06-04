using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombieWalker;
    [SerializeField] private GameObject zombieRunner;
    [SerializeField] private GameObject zombieTank;
    [SerializeField] private float interval = 1f;

    private int random = 1;
    private GameObject spwn1;
    private GameObject spwn2;
    private GameObject spwn3;
    private GameObject spwn4;

    private int baseZombieWalkerCount = 5;
    private int baseZombieRunnerCount = 2;
    private int baseZombieTankCount = 1;

    private int zombieWalkerCount = 0;
    private int zombieRunnerCount = 0;
    private int zombieTankCount = 0;

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

        StartCoroutine(spawnZW(interval, zombieWalker));
        StartCoroutine(spawnZR(interval, zombieRunner));
        StartCoroutine(spawnZT(interval, zombieTank));
    }

    void Update() {
        random = Random.Range(1,5);
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

            zombieTankCount ++;
            GameManager.zombiesAlive ++;
        }
    }

    // resetta i contatori per la prossima ondata
    public void ResetValues(){

        zombieWalkerCount = 0;
        zombieRunnerCount = 0;
        zombieTankCount = 0;
    }
}
