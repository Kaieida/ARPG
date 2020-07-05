using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Characters
{
    private static Enemy instance;
    public static Enemy Instance { get => instance; set => instance = value; }
    [SerializeField]
    Animator animator;
    bool isAttacking = false;
    //public int expWorth;
    
    public EnemyData data;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        //data.maxHealth = 5;
        health = data.maxHealth;
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
        if (health <= 0)
        {
            Player.Instance.ExpGain(data.expWorth);
            animator.SetTrigger("Dead");
            Destroy(this.gameObject,1.5f);
        }
        
    }
    IEnumerator EnemyAttack(float distance)
    {
        isAttacking = true;
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Attack");
        if (distance <= 2)
            Player.Instance.DamageTaken(1);
    }
}
