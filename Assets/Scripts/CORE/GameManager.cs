using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public PlayerController[] players;
    public CameraManager cameraMain;

    // Timer vars
    public float startTime;
    public TextMeshProUGUI timeText;

    public int done = 0;

    void Start()
    {
        EventManager.OnButtonSwitchEvent -= SwitchPlayer;
        EventManager.OnButtonSwitchEvent += SwitchPlayer;

        cameraMain.target = players[0].transform;

        startTime = Time.time;
    }

    void Update()
    {
        done = VARS.doneCount;
        float time = Time.time - startTime;

        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("F2");

        timeText.text = minutes + ":" + seconds;

        if (Input.GetKeyUp(KeyCode.Space))
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

    public void stopTimer()
    {
        // Ja abi speletaji sasniedz atvertas durvis, taimeris apstajas.
        // Taimeris apstajas tieshi taja bridi, kad pedejais speletajs ir sasniedzis durvis.
    }
}
