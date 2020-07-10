using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilities : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    GameObject fireAbility;
    void Start()
    {
        player = GameObject.Find("Player(Clone)");
        StartCoroutine(FireAbility());
    }
    IEnumerator FireAbility()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 20)
            {
                GameObject firePillar = Instantiate(fireAbility, player.transform.position, Quaternion.Euler(-90,0,0));
                Destroy(firePillar, 2f);
                //Debug.Log("Casting ability");
                yield return new WaitForSeconds(10f);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    
}
