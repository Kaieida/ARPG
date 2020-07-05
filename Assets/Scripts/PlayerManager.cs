using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
    /*IEnumerator PlayerSave()
    {
        Debug.Log("Save initialized");
        Player.Instance.SavePlayer();
        yield return new WaitForSeconds(5f);
        Debug.Log("Save complete");
    }*/
    private void Update()
    {
        //StartCoroutine(PlayerSave());
        if (Input.GetKeyDown(KeyCode.L))
        {
            Player.Instance.LoadPlayer();
            Debug.Log("Save loaded");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Player.Instance.SavePlayer();
            Debug.Log("Save complete");
        }
    }
}
