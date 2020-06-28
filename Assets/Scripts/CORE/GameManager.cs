using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public PlayerController[] players;
    public CameraManager cameraMain;

    public GameObject[] levels;

    public GameObject currentLevel;
    public int lvlID;

    // Timer vars
    public float startTime;
    public TextMeshProUGUI timeText;

    public bool gameStarted = false;

    public int done = 0;
    public GameObject menuContainer;
    public GameObject gameContainer;

    private Vector2 emptyVector = new Vector2(0, 0);

    void Start()
    {
        EventManager.OnButtonSwitchEvent -= SwitchPlayer;
        EventManager.OnButtonSwitchEvent += SwitchPlayer;

        cameraMain.target = players[0].transform;

        startTime = Time.time;
    }

    void Update()
    {
        if (gameStarted)
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


            if (VARS.doneCount == 2)
            {
                Debug.Log("Next Level");
                NextLevel();
            }
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

    public void StartGame()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int _index)
    {
        /*
        set active canvas containers
         */
        menuContainer.SetActive(false);
        gameContainer.SetActive(true);
        lvlID = _index;
        currentLevel = levels[_index];
        levels[_index].SetActive(true);
        SetPlayers(true, GetPlayerSpawns(currentLevel.transform));
    }

    private void SetPlayers(bool _active, Vector2[] _positions)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(_active);
            players[i].gameObject.transform.position = _positions[i];
        }
    }

    private void SetPlayers(bool _active)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(_active);
        }
    }

    public void ResetPlayerPos(GameObject _player, string _tag)
    {
        Vector2[] posX = GetPlayerSpawns(currentLevel.transform);
        if (_tag == "Male")
        {
            _player.transform.position = posX[0];
        }
        if (_tag == "Female")
        {
            _player.transform.position = posX[1];
        }

    }

    public Vector2[] GetPlayerSpawns(Transform _parent)
    {
        Vector2[] positions = { new Vector2(), new Vector2() };

        positions[0] = _parent.GetChild(0).GetChild(0).position;
        positions[1] = _parent.GetChild(0).GetChild(1).position;

        return positions;
    }

    public void NextLevel()
    {
        if (lvlID + 1 < levels.Length)
            LoadLevel(lvlID + 1);
    }
}
