using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EndGame : MonoBehaviour
{
    private bool isGameOver;
    [SerializeField] GameObject endingUI;
    public float secondsSurvived;
    private float finalSecondsSurvived;
    public int moneyCollected;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text moneyText;

    private Treasure[] treasureList;
    private bool isAllTreasureCollected = false;

    // This script handles tracking the score and also the end of the game

    void Start()
    {
        endingUI.SetActive(false);
        secondsSurvived = 0f;
        moneyCollected = 0;

        treasureList = FindObjectsOfType<Treasure>();
        print("there are " + treasureList.Length + "treasures to find");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            secondsSurvived += Time.deltaTime;
            timeText.text = secondsSurvived.ToString("0.00");
            moneyText.text = "$" + moneyCollected.ToString("n0") + " recovered";
        }

        foreach (Treasure treasure in treasureList)
        {
            isAllTreasureCollected = true;
            if(treasure.IsTreasureOpened() == false)
            {
                isAllTreasureCollected = false;
                break;
            }
        }

        // if all treasure has been collected then end the game
        if (isAllTreasureCollected && isGameOver == false)
        {
            EndTheGame();
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

        //disable leak spawning
        GameObject.Find("LeakSpawner").GetComponent<NewSpawnScript>().DisableSpawning();

        finalSecondsSurvived = secondsSurvived;

        int timeScore = (int)(finalSecondsSurvived * 100f);
        int moneyScore = moneyCollected;
        int totalScore = timeScore + moneyScore;

        string endingResult = "ending";
        if (moneyCollected < 1)
        {
            endingResult = "No treasure recovered...so much for retirement!";
        } else if (moneyCollected < 3000)
        {
            endingResult = "Grabbed a bit o' treasure...could ya get more?";
        } else if (moneyCollected < 6600)
        {
            endingResult = "Got a lot o' treasure! A fine retirement...but still some left. Can ya get it all?";
        } else
        {
            endingResult = "YOU WIN!! All treasure recovered!! Time to retire with ya family in peace!!";
        }

        scoreText.text = endingResult + "\n\nTreasure Recovered: $" + moneyCollected + "\n\nPress Enter to play again!";

        //scoreText.text = "You've gone down with yer ship! \n\n Time Score: " + timeScore + "\nMoney Score: " + moneyScore + "\n\nTotal Score: " + totalScore + "\n\nPress Enter to Play Again";

    }


}
