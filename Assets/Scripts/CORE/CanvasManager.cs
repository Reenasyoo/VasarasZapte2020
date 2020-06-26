using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ButtonLeft()
    {
        EventManager.ButtonLeftEvent();
    }

    public void ButtonRight()
    {
        EventManager.ButtonRightEvent();
    }

    public void ButtonUp()
    {
        EventManager.ButtonUpEvent();
    }

    public void ButtonSwitch()
    {
        EventManager.ButtonSwitchEvent();
    }
}
