using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    Camera cam;
    GameObject player;
    private void Awake()
    {
       
    }
    void Start()
    {
        player = GetComponent<GameObject>();
        cam = Camera.main; 
    }

    void Update()
    {
        cam.transform.position = player.transform.position + new Vector3(0, 30, -30);
    }
}
