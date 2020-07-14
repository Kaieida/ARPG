using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    void Start()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
