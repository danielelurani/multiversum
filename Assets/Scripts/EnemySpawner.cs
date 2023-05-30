using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombieWalker;
    [SerializeField] private float interval = 1f;

    private int zombieWalkerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(interval, zombieWalker));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemyType){

        while(zombieWalkerCount < 10){

            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyType, transform.position, Quaternion.identity);
            zombieWalkerCount ++;
        }
    }
}
