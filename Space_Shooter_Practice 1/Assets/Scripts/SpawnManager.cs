using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] public int maxEnemies = 5;
    int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool CanSpawn()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount < maxEnemies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (CanSpawn())
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-2.0f, 2.0f), 4.7f, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
