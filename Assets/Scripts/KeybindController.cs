using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class KeybindController : MonoBehaviour
{
    private static KeybindController instance;
    public static KeybindController Instance { get => instance; set => instance = value; }

    public List<KeyCode> Keybinds = new List<KeyCode>();
    public Dictionary<KeyCode, UnityEvent> eventKeyBindsDown = new Dictionary<KeyCode, UnityEvent>();
    public Dictionary<KeyCode, UnityEvent> eventKeyBindsUp = new Dictionary<KeyCode, UnityEvent>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyCode key in Keybinds)
        {
            if (Input.GetKeyDown(key))
            {
                eventKeyBindsDown[key].Invoke();
                
            }
            if (Input.GetKeyUp(key))
            {
                eventKeyBindsUp[key].Invoke();
            }
        }
    }
    public void AddListener(KeyCode key, UnityAction eventDown, UnityAction eventUp)
    {
        if (!eventKeyBindsDown.ContainsKey(key))
        {
            eventKeyBindsDown.Add(key, new UnityEvent());
        }
        if (!eventKeyBindsUp.ContainsKey(key))
        {
            eventKeyBindsUp.Add(key, new UnityEvent());
        }
        eventKeyBindsDown[key].AddListener(eventDown);
        eventKeyBindsUp[key].AddListener(eventUp);
    }
    public void RemoveListener(KeyCode key, UnityAction eventDown, UnityAction eventUp)
    {
        if (!eventKeyBindsDown.ContainsKey(key))
        {
            eventKeyBindsDown.Add(key, new UnityEvent());
        }
        if (!eventKeyBindsUp.ContainsKey(key))
        {
            eventKeyBindsUp.Add(key, new UnityEvent());
        }
        eventKeyBindsDown[key].RemoveListener(eventDown);
        eventKeyBindsUp[key].RemoveListener(eventUp);
    }
}
