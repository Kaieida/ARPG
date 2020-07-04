using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LocationChange : MonoBehaviour, IPointerClickHandler
{
    public int levelIndex;
    public void OnPointerClick(PointerEventData eventData)
    {
        float distance = Vector3.Distance(Player.Instance.transform.position, transform.position);
        if (distance <= 3)
        {
            Debug.Log("Changing location!");
            SceneManager.LoadScene(levelIndex);
        }
    }
}
