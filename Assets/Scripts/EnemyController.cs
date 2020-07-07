using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 50f;
    [SerializeField]
    Transform target;
    NavMeshAgent agent;
    public Animator anim;
    void Start()
    {
        target = Player.Instance.transform;
        agent = GetComponent<NavMeshAgent>();

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        RaycastHit hit;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && Physics.Raycast(transform.position, target.position - transform.position, out hit))
        {
            if (hit.transform.name == "Player(Clone)")
            {
                agent.SetDestination(target.position);
                anim.SetFloat("MoveSpeed",agent.speed);
            }
        } 
    }
}
