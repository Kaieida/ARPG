using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilities : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    GameObject fireAbility;
    [SerializeField]
    GameObject fireVoidZone;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(FireAbility());
    }
    IEnumerator FireAbility()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 20)
            {
                GameObject fireZone = Instantiate(fireVoidZone, player.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                GameObject firePillar = Instantiate(fireAbility, fireZone.transform.position, Quaternion.Euler(-90,0,0));
                Destroy(fireZone);
                Destroy(firePillar, 4f);
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
