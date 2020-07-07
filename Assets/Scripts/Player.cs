using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : Characters
{
    private static Player instance;
    public static Player Instance { get => instance; set => instance = value; }
    public PlayerData data;
    public Animator anim;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        slider = GameObject.Find("Health bar").GetComponent<Slider>();
        //agent = GetComponent<NavMeshAgent>();
        //maxHealth = 5;
        data.health = data.maxHealth;
        SetMaxHealth(data.maxHealth);
    }
    void Update()
    {
        //Die(); Right now it's useless, return this method when enemy Die(); is fixed.
        anim.SetFloat("MoveSpeed", GetComponent<NavMeshAgent>().speed);
    }
    public override bool DamageTaken(int damage)
    {
        data.health -= damage;
        SetHealth(data.health);
        return data.health <= 0;
    }
    public int ExpGain(int exp)
    {
        data.experience += exp;
        return data.level = data.experience / 90 + 10 * data.level;
    }
    /*public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        experience = data.experience;
    }*/
}
