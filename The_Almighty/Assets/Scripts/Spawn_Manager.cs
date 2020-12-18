using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    //_enemyPrefabUp

    void Start()
    {
        
    }


    void Update()
    {
        int randomSpawn= Random.Range(1,5);

        if(Input.GetKeyDown(KeyCode.L))
        {
            switch(randomSpawn)
            {
                //x down
                case 1:
                Debug.Log("It alive");
                Instantiate(_enemyPrefab, new Vector3(Random.Range(-3.21f, 3.21f),4.46f, 0), Quaternion.identity);
                break;

                // x up
                case 2:
                Debug.Log("it ded");
                Instantiate(_enemyPrefab, new Vector3(Random.Range(-3.21f, 3.21f),-4.47f, 0), Quaternion.identity);
                break;

                // y left
                case 3:
                Debug.Log("fuck u");
                Instantiate(_enemyPrefab, new Vector3(3.22f, Random.Range(-4.45f, 4.45f),0), Quaternion.identity);
                break;

                //y right
                case 4:
                Debug.Log("fuck me");
                Instantiate(_enemyPrefab, new Vector3(-3.23f, Random.Range(-4.45f, 4.45f),0), Quaternion.identity);
                break;

        }
        }
    }
}
