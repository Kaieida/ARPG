using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cyclone : Player
{
    public List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        slider = GameObject.Find("Health bar").GetComponent<Slider>();
        data.health = data.maxHealth;
        SetMaxHealth(data.maxHealth);
        KeybindController.Instance.AddListener(KeyCode.Q, StartCyclone, StopCyclone);
    }
    private void OnDestroy()
    {
        KeybindController.Instance.RemoveListener(KeyCode.Q, StartCyclone, StopCyclone);
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
            transform.Rotate(new Vector3(0, 360 * Time.deltaTime * 3, 0));
            yield return null;
        }
    }
    private void Update()
    {
        Debug.Log(data.health);
        anim.SetTrigger("Speed");
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
