using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Slider slider;
    int damage;
    public Characters()
    {

    }
    public virtual void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public bool DamageTaken(int damage)
    {
        health -= damage;
        SetHealth(health);
        return health <= 0;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
