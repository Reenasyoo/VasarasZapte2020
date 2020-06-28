using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public GameObject pausePanel;
    public GameObject gameOverPanel;


    private bool gamePaused = false;

    private void Start()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(!gamePaused) 
            {
                PauseGame();
            }
            else 
            {
                ResumeGame();
            }
        }
    }

    private void Update()
    {
        pointsText.text = VARS.points.ToString();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }
}
