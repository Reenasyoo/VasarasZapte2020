using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonLeftEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.ButtonLeftEvent(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.ButtonLeftEvent(false);
    }
}
