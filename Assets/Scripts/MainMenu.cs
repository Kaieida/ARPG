using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject _panel;
    public GameObject[] playerClasses;
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        _panel.SetActive(true);
    }
    public void CloseTab()
    {
        _panel.SetActive(false);
    }
    public void WarriorSelection()
    {
        GameObject.Find("TempObjectForPlayerSpawn").GetComponent<PlayerSpawner>().player = playerClasses[0];
        SceneManager.LoadScene(0);
    }
    public  void ArcherSelection()
    {
        GameObject.Find("TempObjectForPlayerSpawn").GetComponent<PlayerSpawner>().player = playerClasses[1];
        SceneManager.LoadScene(0);
    }
}
