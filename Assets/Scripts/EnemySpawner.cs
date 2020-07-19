using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject skeleton;
    [SerializeField]
    bool _isItCity;
    public GameObject[] enemySpawnPoints;
    void Start()
    {
        
        if (!_isItCity)
        {
            for (int i = 0; i < 3; i++)
                Instantiate(enemy, enemySpawnPoints[i].transform.position, Quaternion.identity);
            Instantiate(skeleton, enemySpawnPoints[4].transform.position, Quaternion.identity);
        }
    }
}
