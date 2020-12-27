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
    void Start()
    {
        
    }


    void Update()
    {
        if(nextSpawn>0)
        {
            nextSpawn -= Time.deltaTime;
        }
        if(nextSpawn <= 0)
        {
            Spawn();
        }
        
    }

    private void Spawn()
    {
        nextSpawn = spawnRate;
        Vector2 position = spawnPosition[Random.Range(0,spawnPosition.Length)].transform.position;
        GameObject enemiesClone = Instantiate (enemies[Random.Range(0, enemies.Length)],new Vector2(position.x, position.y), transform.rotation);
        enemiesClone.SetActive(true);
    }
}
