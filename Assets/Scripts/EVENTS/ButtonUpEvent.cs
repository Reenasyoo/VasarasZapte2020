using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonUpEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.ButtonUpEvent(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.ButtonUpEvent(false);
    }
}
