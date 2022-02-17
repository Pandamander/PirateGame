using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject topOfship;
    [SerializeField] GameObject topOfWater;
    private bool isGameOver;
    [SerializeField] GameObject endingUI;
    private float secondsSurvived;
    private int finalSecondsSurvived;
    [SerializeField] Text scoreText;

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

        secondsSurvived += Time.deltaTime;
    }

    void EndTheGame()
    {
        isGameOver = true;
        endingUI.SetActive(true);

        finalSecondsSurvived = (int)secondsSurvived;
        scoreText.text = "You survived for: " + finalSecondsSurvived + " seconds";

    }


}
