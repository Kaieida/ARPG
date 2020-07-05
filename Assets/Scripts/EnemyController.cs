using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
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
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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
                if (distance <= agent.stoppingDistance)
                {
                    while(Enemy.Instance.health >= 1)
                    {
                        FaceTarget();
                    }
                    
                }
            }
        } 
    }
}
