using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    private static HealthSystem instance;
    public static HealthSystem Instance { get => instance; set => instance = value; }

    [SerializeField]
    private GameObject canvasHP;
    [SerializeField]
    private TextMeshProUGUI canvasText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void ShowHealthSystem(EnemyData data)
    {
        canvasHP.SetActive(true);
        canvasText.text = data.enemyName;
        canvasHP.GetComponent<Slider>().maxValue = data.maxHealth;
        canvasHP.GetComponent<Slider>().value = data.health;
    }
    public void HideHealthSystem()
    {
        canvasHP.SetActive(false);
    }
}
