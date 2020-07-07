using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Characters
{
    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }
    Animator animator;
    bool isAttacking = false;
    public EnemyData _data;
    private EnemyData data;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        data = Instantiate(_data);
        animator = GetComponentInChildren<Animator>();
        data.health = data.maxHealth;
        SetMaxHealth(data.health);
    }
    void Update()
    {
        float distance = Vector3.Distance(Player.Instance.transform.position, transform.position);
        Attacking(distance);
        Die();
    }
    void Attacking(float distance)
    {
        if (distance <= 5)
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
    public override bool DamageTaken(int damage)
    {
        data.health -= damage;
        SetHealth(data.health);
        return data.health <= 0;
    }
    public void Die()
    {
        if (data.health <= 0)
        {
            animator.SetTrigger("Dead");
            Destroy(this.gameObject,1.5f);
            Player.Instance.ExpGain(data.expWorth);
        }
    }
    IEnumerator EnemyAttack(float distance)
    {
        isAttacking = true;
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Attack");
        if (distance <= 4)
            Player.Instance.DamageTaken(1);
        isAttacking = false;
    }
}
