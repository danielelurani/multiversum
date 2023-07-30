using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelSpawner : MonoBehaviour
{
    public static bool zombiesCanSpawn;

    [SerializeField] private GameObject bossHealthbar;
    [SerializeField] private GameObject zombieWalker;
    [SerializeField] private GameObject zombieRunner;
    [SerializeField] private GameObject zombieTank;
    [SerializeField] private GameObject boss;

    private int random = 1;
    private GameObject bossSpwn;
    private GameObject spwn1;
    private GameObject spwn2;
    private GameObject spwn3;
    private GameObject spwn4;

    // Start is called before the first frame update
    void Start()
    {
        zombiesCanSpawn = true;

        // trova gli spawn
        bossSpwn = GameObject.Find("BossSpawner");
        spwn1 = GameObject.Find("Spawn1");
        spwn2 = GameObject.Find("Spawn2");
        spwn3 = GameObject.Find("Spawn3");
        spwn4 = GameObject.Find("Spawn4");

        // carica gli assets necessari per gli zombie
        zombieWalker = Resources.Load<GameObject>("Prefabs/ZombieWalker");
        zombieRunner = Resources.Load<GameObject>("Prefabs/ZombieRunner");
        zombieTank = Resources.Load<GameObject>("Prefabs/ZombieTank");
        boss = Resources.Load<GameObject>("Prefabs/Boss");
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(1,5);
    }

    public void StartWave(){

        spawnBoss(boss);
        StartCoroutine(spawnZW(5f, zombieWalker));
        StartCoroutine(spawnZR(10f, zombieRunner));
        StartCoroutine(spawnZT(15f, zombieTank));
    }

    private void spawnBoss(GameObject enemyType){

        GameObject newEnemy = Instantiate(enemyType, bossSpwn.transform.position, Quaternion.identity);
        bossHealthbar.SetActive(true);
    }

    private IEnumerator spawnZW(float interval, GameObject enemyType){

        while(zombiesCanSpawn){

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
            
            GameManager.zombiesAlive ++;
        }
    }

    private IEnumerator spawnZR(float interval, GameObject enemyType){

        while(zombiesCanSpawn){

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
            
            GameManager.zombiesAlive ++;
        }
    }

    private IEnumerator spawnZT(float interval, GameObject enemyType){

        while(zombiesCanSpawn){

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
            
            GameManager.zombiesAlive ++;
        }
    }
}
