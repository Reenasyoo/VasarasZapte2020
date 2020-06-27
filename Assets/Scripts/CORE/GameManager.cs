using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController[] players;
    public CameraManager cameraMain;

    void Start()
    {
        Debug.Log(VARS.test);
        EventManager.OnButtonSwitchEvent += SwitchPlayer;

        // VARS.gameCamera.target = 
        cameraMain.target = players[0].transform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer(bool _eventBool = false)
    {
        Debug.Log("Button Switch" + _eventBool);
        if (players[0].thisActive)
        {
            players[0].thisActive = false;
            players[1].thisActive = true;
            // VARS.gameCamera.target = players[1].transform;
            cameraMain.target = players[1].transform;
        }
        else
        {
            players[0].thisActive = true;
            players[1].thisActive = false;
            // VARS.gameCamera.target = players[0].transform;
            cameraMain.target = players[0].transform;
        }
    }
}
