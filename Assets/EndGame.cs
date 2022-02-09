using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject topOfship;
    [SerializeField] GameObject topOfWater;
    private bool isGameOver;
    [SerializeField] GameObject endingUI;

    // Start is called before the first frame update
    void Start()
    {
        endingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (topOfship.transform.position.y < topOfWater.transform.position.y && !isGameOver)
        {
            EndTheGame();
        }
    }

    void EndTheGame()
    {
        isGameOver = true;
        endingUI.SetActive(true);

    }
}
