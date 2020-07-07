using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int expWorth;
    public int maxHealth;
    public int health;
    public int damage;
}
