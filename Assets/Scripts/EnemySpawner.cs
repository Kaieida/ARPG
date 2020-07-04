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
    void Start()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        if (!isItCity)
        {
            for (int i = 0; i < 5; i++)
                Instantiate(enemy, new Vector3(Random.Range(-5, 34), 42.2f, (Random.Range(-2, -50))), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
