using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

public GameObject[] enemies;
public GameObject[] spawnPosition;

[SerializeField]
private float spawnRate;

[SerializeField]
private float nextSpawn;

//fuel
public GameObject[] fuel;
public GameObject[] spawnPosition2;

[SerializeField]
private float spawnRateF;

[SerializeField]
private float nextSpawnF;
    void Update()
    {
        EnemiesNextSpawn();
        FuelNextSpawn();
    }

    void EnemiesNextSpawn()
    {
        if(nextSpawn>0)
        {
            nextSpawn -= Time.deltaTime;
        }
        if(nextSpawn <= 0)
        {
            SpawnEnemies();
        }
    }

    void FuelNextSpawn()
    {
        if(nextSpawnF>0)
        {
        nextSpawnF -= Time.deltaTime;
        }
        if(nextSpawnF <= 0)
        {
            SpawnFuel();
        }
    }


    private void SpawnEnemies()
    {
        nextSpawn = spawnRate;
        Vector2 position = spawnPosition[Random.Range(0,spawnPosition.Length)].transform.position;
        GameObject enemiesClone = Instantiate (enemies[Random.Range(0, enemies.Length)],new Vector2(position.x, position.y), transform.rotation);
        enemiesClone.SetActive(true);
    }

    private void SpawnFuel()
    {
        nextSpawnF = spawnRateF;
        Vector2 position2 = spawnPosition2[Random.Range(0,spawnPosition2.Length)].transform.position;
        GameObject FuelClone = Instantiate (fuel[Random.Range(0, fuel.Length)],new Vector2(position2.x, position2.y), transform.rotation);
        FuelClone.SetActive(true);
    }
}
