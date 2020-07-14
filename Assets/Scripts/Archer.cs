using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Archer : Player
{
    [SerializeField]
    GameObject arrow;
    private GameObject arrowCopy;
    void Start()
    {
        slider = GameObject.Find("Health bar").GetComponent<Slider>();
        data.health = data.maxHealth;
        SetMaxHealth(data.maxHealth);
        //StartCoroutine(ShootArrow());
        KeybindController.Instance.AddListener(KeyCode.Q, ShootArrow, DestroyArrow);
    }
    private void OnDestroy()
    {
        KeybindController.Instance.RemoveListener(KeyCode.Q, ShootArrow, DestroyArrow);
    }

            
    private void ShootArrow()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            {
              GameObject arr = Instantiate(arrow, gameObject.transform.position+new Vector3(0, 3, 0)+transform.forward, transform.rotation);
            arr.GetComponent<Arrow>().CoordinateTranslation(transform.forward);
            }
    }
    private void DestroyArrow()
    {

    }
}

