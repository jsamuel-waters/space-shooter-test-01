using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] float spawnRate = 7.5f;
    [SerializeField] public int spawnNumber = 5;
    
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject enemyContainer;

    int enemyCount;
    bool bossSpawned = false;
    public int enemiesDestroyed = 0;
    public int requiredEnemiesDestroyed = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        // enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount = enemyContainer.transform.childCount;
    }


    IEnumerator SpawnEnemies()
    {
        while (enemyCount < spawnNumber)
        {
            if (enemiesDestroyed < requiredEnemiesDestroyed)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-2.0f, 2.0f), 4.7f, 0);
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = enemyContainer.transform;
                Debug.Log(enemyCount);
            }
            else if (enemiesDestroyed >= requiredEnemiesDestroyed && !bossSpawned)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-2.0f, 2.0f), 4.7f, 0);
                GameObject newEnemy = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = enemyContainer.transform;
                Debug.Log(enemyCount);
                bossSpawned = true;
            }
            else
                break;

            yield return new WaitForSeconds(spawnRate);
        }


    }

}
