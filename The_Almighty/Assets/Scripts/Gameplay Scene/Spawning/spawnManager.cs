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

//Powerup
public GameObject[] Powerups;
public GameObject[] spawnPosition3;
[SerializeField]
private float spawnRateP, NextSpawnP;

//Coins
public GameObject[] Coins;
public GameObject[] spawnPosition4;
[SerializeField]
private float spawnRateC, NextSpawnC;


    void Update()
    {
        EnemiesNextSpawn();
        FuelNextSpawn();
        PowerupsNextSpawn();
        CoinsNextSpawn();
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

    void PowerupsNextSpawn()
    {
        if(NextSpawnP>0)
        {
            NextSpawnP -= Time.deltaTime;
        }
        if(NextSpawnP <= 0) 
        {
            SpawnPowerup();
        }
        
    }

    void CoinsNextSpawn()
    {
        if(NextSpawnC > 0)
        {
            NextSpawnC -= Time.deltaTime;
        }
        if(NextSpawnC <= 0)
        {
            SpawnCoins();
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

    private void SpawnPowerup()
    {
        NextSpawnP = spawnRateP;
        Vector2 position3 = spawnPosition3[Random.Range(0,spawnPosition3.Length)].transform.position;
        GameObject PowerupsClone = Instantiate (Powerups[Random.Range(0, fuel.Length)],new Vector2(position3.x, position3.y), transform.rotation);
        PowerupsClone.SetActive(true);
    }

    private void SpawnCoins()
    {
        NextSpawnC = spawnRateC;
        Vector2 position4 = spawnPosition4[Random.Range(0,spawnPosition3.Length)].transform.position;
        GameObject CoinsClone = Instantiate (Coins[Random.Range(0, fuel.Length)],new Vector2(position4.x, position4.y), transform.rotation);
        CoinsClone.SetActive(true);
    }
}
