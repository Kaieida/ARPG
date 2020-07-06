using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    [SerializeField]
    bool isItCity;
    public GameObject spawnPoint;
    public GameObject[] enemySpawnPoints;
    void Start()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        if (!isItCity)
        {
            for (int i = 0; i < 4; i++)
                Instantiate(enemy, enemySpawnPoints[i].transform.position, Quaternion.identity);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
