using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public Button left;

    private void Start()
    {
        // left.OnPointerDown.AddListener(() => { ButtonLeft(); });
        // EventTrigger trigger = left.gameObject.AddComponent<EventTrigger>();
        // var pointerDown = new EventTrigger.Entry();
        // pointerDown.eventID = EventTriggerType.PointerDown;
        // pointerDown.callback.AddListener((e) => ButtonLeft );
        // trigger.triggers.Add(pointerDown);
    }

    private void Update()
    {

    }

    // public void ButtonLeft()
    // {
    //     // EventManager.ButtonLeftEvent();
    // }

    // public void ButtonRight()
    // {
    //     EventManager.ButtonRightEvent();
    // }

    // public void ButtonUp()
    // {
    //     EventManager.ButtonUpEvent();
    // }

    // public void ButtonSwitch()
    // {
    //     EventManager.ButtonSwitchEvent();
    // }
}
