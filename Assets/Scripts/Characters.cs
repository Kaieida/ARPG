using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    private int health;
    public Slider slider;
    //int damage;
    public Characters()
    {

    }
    /*public virtual void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }*/
    public virtual bool DamageTaken(int damage)
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
