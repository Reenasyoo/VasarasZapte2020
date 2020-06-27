using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonRightEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.ButtonRightEvent(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.ButtonRightEvent(false);
    }
}
