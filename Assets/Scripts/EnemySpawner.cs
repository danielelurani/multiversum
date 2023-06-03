using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombieWalker;
    [SerializeField] private GameObject zombieRunner;
    [SerializeField] private float interval = 1f;

    private int zombieWalkerCount = 0;
    private int zombieRunnerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnZW(interval, zombieWalker));
        StartCoroutine(spawnZR(interval, zombieRunner));
    }

    private IEnumerator spawnZW(float interval, GameObject enemyType){

        while(zombieWalkerCount < 10){

            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyType, transform.position, Quaternion.identity);

            zombieWalkerCount ++;
        }
    }

    private IEnumerator spawnZR(float interval, GameObject enemyType){

        while(zombieRunnerCount < 3){

            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyType, transform.position, Quaternion.identity);

            zombieRunnerCount ++;
        }
    }
}
