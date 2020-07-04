using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Characters
{
    [SerializeField]
    Animator animator;
    bool isAttacking = false;
    public int expWorth;
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = 5;
        health = maxHealth;
        SetMaxHealth(health);
    }
    void Update()
    {
        float distance = Vector3.Distance(Player.Instance.transform.position, transform.position);
        Attacking(distance);
        Die();
    }
    void Attacking(float distance)
    {
        if (distance <= 2)
        {
            if (!isAttacking)
                StartCoroutine(EnemyAttack(distance));
        }
        else
        {
            if (isAttacking)
            {
                isAttacking = false;
                StopAllCoroutines();
            }
        }
    }
    public override void Die()
    {
        base.Die();
        Player.Instance.ExpGain(expWorth);
    }
    IEnumerator EnemyAttack(float distance)
    {
        isAttacking = true;
        yield return new WaitForSeconds(1);
        animator.SetTrigger("checkForAttacking");
        if (distance <= 2)
            Player.Instance.DamageTaken(1);
    }
}
