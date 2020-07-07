using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int experience;
    public int level;
    public int maxHealth;
    public int health;
}
