using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController[] players;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnButtonSwitchEvent += SwitchPlayer;
    }

    // Update is called once per frame
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
        }
        else
        {
            players[0].thisActive = true;
            players[1].thisActive = false;
        }
    }
}
