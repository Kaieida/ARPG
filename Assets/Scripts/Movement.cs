using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    Camera cam;
    public NavMeshAgent agent;
    private void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        cam.transform.position = agent.transform.position + new Vector3(0,45,-15);
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
