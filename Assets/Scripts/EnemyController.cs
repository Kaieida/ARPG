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
        StartCoroutine(EnemiesMovement());

    }
    IEnumerator EnemiesMovement()

    {
        while (true)
        {
            RaycastHit hit;
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius && Physics.Raycast(transform.position, target.position - transform.position, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    agent.SetDestination(target.position);
                    anim.SetFloat("MoveSpeed", agent.speed);
                }

            }
            yield return null;
        }
    }
}
