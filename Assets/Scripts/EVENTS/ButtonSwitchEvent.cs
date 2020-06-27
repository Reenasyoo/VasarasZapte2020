using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonSwitchEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.ButtonSwitchEvent(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.ButtonSwitchEvent(false);
    }
}
