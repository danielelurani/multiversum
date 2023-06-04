using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombieWalker;
    [SerializeField] private GameObject zombieRunner;
    [SerializeField] private GameObject zombieTank;
    [SerializeField] private float interval = 1f;

    private int baseZombieWalkerCount = 5;
    private int baseZombieRunnerCount = 2;
    private int baseZombieTankCount = 1;

    private int zombieWalkerCount = 0;
    private int zombieRunnerCount = 0;
    private int zombieTankCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        // carica gli assets necessari per gli zombie
        zombieWalker = Resources.Load<GameObject>("Prefabs/ZombieWalker");
        zombieRunner = Resources.Load<GameObject>("Prefabs/ZombieRunner");
        zombieTank = Resources.Load<GameObject>("Prefabs/ZombieTank");

        StartCoroutine(spawnZW(interval, zombieWalker));
        StartCoroutine(spawnZR(interval, zombieRunner));
        StartCoroutine(spawnZT(interval, zombieTank));
    }

    private IEnumerator spawnZW(float interval, GameObject enemyType){

        while(zombieWalkerCount < baseZombieWalkerCount * GameManager.currentWave){

            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyType, transform.position, Quaternion.identity);

            zombieWalkerCount ++;
            GameManager.zombiesAlive ++;
        }
    }

    private IEnumerator spawnZR(float interval, GameObject enemyType){

        while(zombieRunnerCount < baseZombieRunnerCount * GameManager.currentWave){

            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyType, transform.position, Quaternion.identity);

            zombieRunnerCount ++;
            GameManager.zombiesAlive ++;
        }
    }

    private IEnumerator spawnZT(float interval, GameObject enemyType){

        while(zombieTankCount < baseZombieTankCount * GameManager.currentWave){

            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyType, transform.position, Quaternion.identity);

            zombieTankCount ++;
            GameManager.zombiesAlive ++;
        }
    }
}
