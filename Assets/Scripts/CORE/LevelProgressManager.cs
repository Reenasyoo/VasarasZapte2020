using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressManager : MonoBehaviour
{
    // Timer vars
    public float startTime;
    public Text timeText;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time - startTime;

        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("F2");

        timeText.text = minutes + ":" + seconds;
    }

    public void stopTimer() 
    {
        // Ja abi speletaji sasniedz atvertas durvis, taimeris apstajas.
        // Taimeris apstajas tieshi taja bridi, kad pedejais speletajs ir sasniedzis durvis.
    }
}
