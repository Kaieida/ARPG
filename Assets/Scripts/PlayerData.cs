using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int experience;
    public int level;
    public Scene scene;

    public PlayerData(Player player)
    {
        level = player.level;
        experience = player.experience;
    }
}
