using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : Characters
{
    private static Player instance;
    public static Player Instance { get => instance; set => instance = value; }
    //public Slider slider;
    public int experience;
    public int level;
    public HealthSystem healthSystem;
    public Animator anim;
    //NavMeshAgent agent;
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
        maxHealth = 5;
        health = maxHealth;
        SetMaxHealth(maxHealth);
    }
    void Update()
    {
        Die();
        anim.SetFloat("MoveSpeed", GetComponent<NavMeshAgent>().speed);
    }
    public int ExpGain(int exp)
    {
        experience += exp;
        return level = experience / 3;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        experience = data.experience;
    }
}
