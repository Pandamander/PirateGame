using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject topOfship;
    [SerializeField] GameObject topOfWater;
    private bool isGameOver;
    [SerializeField] GameObject endingUI;
    private float secondsSurvived;
    private float finalSecondsSurvived;
    [SerializeField] Text scoreText;
    [SerializeField] TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        endingUI.SetActive(false);
        secondsSurvived = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
        {
            EndTheGame();
        }
        else
        {
            secondsSurvived += Time.deltaTime;
            timeText.text = secondsSurvived.ToString("0.00");
        }

        
    }

    public void EndTheGame()
    {
        isGameOver = true;
        endingUI.SetActive(true);

        finalSecondsSurvived = secondsSurvived;
        scoreText.text = "You survived for: " + finalSecondsSurvived + " seconds";

    }


}
