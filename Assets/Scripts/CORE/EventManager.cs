using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManager : ScriptableObject
{
    public delegate void OnButtonLeftEventDelegate();
    static public event OnButtonLeftEventDelegate OnButtonLeftEvent;
    public static void ButtonLeftEvent()
    {
        if (OnButtonLeftEvent != null)
            OnButtonLeftEvent();
    }

    public delegate void OnButtonRightEventDelegate();
    static public event OnButtonRightEventDelegate OnButtonRightEvent;
    public static void ButtonRightEvent()
    {
        if (OnButtonRightEvent != null)
            OnButtonRightEvent();
    }

    public delegate void OnButtonUpEventDelegate();
    static public event OnButtonUpEventDelegate OnButtonUpEvent;
    public static void ButtonUpEvent()
    {
        if (OnButtonLeftEvent != null)
            OnButtonLeftEvent();
    }

    public delegate void OnButtonSwitchEventDelegate();
    static public event OnButtonSwitchEventDelegate OnButtonSwitchEvent;
    public static void ButtonSwitchEvent()
    {
        if (OnButtonSwitchEvent != null)
            OnButtonSwitchEvent();
    }
}
