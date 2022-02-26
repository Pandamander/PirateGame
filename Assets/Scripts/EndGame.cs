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
    public int moneyCollected;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text moneyText;

    // This script handles tracking the score and also the end of the game

    void Start()
    {
        endingUI.SetActive(false);
        secondsSurvived = 0f;
        moneyCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            secondsSurvived += Time.deltaTime;
            timeText.text = secondsSurvived.ToString("0.00");
            moneyText.text = "$" + moneyCollected.ToString("n0");
        }

        
    }

    public void GetMoney(int howMuch)
    {
        moneyCollected += howMuch;
    }

    public void EndTheGame()
    {
        isGameOver = true;
        endingUI.SetActive(true);

        finalSecondsSurvived = secondsSurvived;

        int timeScore = (int)(finalSecondsSurvived * 100f);
        int moneyScore = moneyCollected;
        int totalScore = timeScore + moneyScore;
        scoreText.text = "You've gone down with yer ship! \n\n Time Score: " + timeScore + "\nMoney Score: " + moneyScore + "\n\nTotal Score: " + totalScore + "\n\nPress Enter to Play Again";

    }


}
