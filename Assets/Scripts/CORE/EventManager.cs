using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManager : ScriptableObject
{
    public delegate void OnButtonLeftEventDelegate(bool _event);
    static public event OnButtonLeftEventDelegate OnButtonLeftEvent;
    public static void ButtonLeftEvent(bool _event)
    {
        if (OnButtonLeftEvent != null)
            OnButtonLeftEvent(_event);
    }

    public delegate void OnButtonRightEventDelegate(bool _event);
    static public event OnButtonRightEventDelegate OnButtonRightEvent;
    public static void ButtonRightEvent(bool _event)
    {
        if (OnButtonRightEvent != null)
            OnButtonRightEvent(_event);
    }

    public delegate void OnButtonUpEventDelegate(bool _event);
    static public event OnButtonUpEventDelegate OnButtonUpEvent;
    public static void ButtonUpEvent(bool _event)
    {
        if (OnButtonUpEvent != null)
            OnButtonUpEvent(_event);
    }

    public delegate void OnButtonSwitchEventDelegate(bool _event);
    static public event OnButtonSwitchEventDelegate OnButtonSwitchEvent;
    public static void ButtonSwitchEvent(bool _event)
    {
        if (OnButtonSwitchEvent != null)
            OnButtonSwitchEvent(_event);
    }
}
