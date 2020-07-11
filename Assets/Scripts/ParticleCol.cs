using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            StartCoroutine(DamagePause());
        }
    }
    IEnumerator DamagePause()
    {
        while (true)
        {
            Player.Instance.DamageTaken(1);
            Debug.Log("Current health " + Player.Instance.data.health);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }
}
