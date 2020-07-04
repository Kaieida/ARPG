using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Characters
{
    private static Player instance;
    public static Player Instance { get => instance; set => instance = value; }
    //public Slider slider;
    public int experience;
    public HealthSystem healthSystem;
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
        maxHealth = 5;
        health = maxHealth;
        SetMaxHealth(maxHealth);
    }
    void Update()
    {
        Die();
    }
    public void ExpGain(int exp)
    {
        experience += exp;
    }
}
