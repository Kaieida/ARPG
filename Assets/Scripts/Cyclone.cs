using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclone : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject player;
    void Start()
    {
        KeybindController.Instance.AddListener(KeyCode.Q, StartCyclone, StopCyclone);
    }
    private void OnDestroy()
    {
        KeybindController.Instance.RemoveListener(KeyCode.Q, StartCyclone, StopCyclone);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        enemies.Remove(other.gameObject);
    }
    IEnumerator Rotate()
    {
        while (true)
        {
            player.transform.Rotate(new Vector3(0, 360 * Time.deltaTime * 3, 0));
            yield return null;
        }
    }
    IEnumerator DamageWait()
    {
        while (true)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].GetComponent<Enemy>().DamageTaken(1))
                {
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
            yield return new WaitForSeconds(0.33f);
        }
    }
    public void StartCyclone()
    {
        StartCoroutine(Rotate());
        StartCoroutine(DamageWait());
    }
    public void StopCyclone()
    {
        //enemies.Clear();
        StopAllCoroutines();
    }
}
