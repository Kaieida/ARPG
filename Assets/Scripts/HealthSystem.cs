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
    private GameObject _canvasHP;
    [SerializeField]
    private TextMeshProUGUI _canvasText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void ShowHealthSystem(EnemyData data)
    {
        _canvasHP.SetActive(true);
        _canvasText.text = data.enemyName;
        _canvasHP.GetComponent<Slider>().maxValue = data.maxHealth;
        _canvasHP.GetComponent<Slider>().value = data.health;
    }
    public void HideHealthSystem()
    {
        _canvasHP.SetActive(false);
    }
}
