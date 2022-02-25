using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FloodFloors : MonoBehaviour
{
    public List<bool> areFloorsFlooded;
    [SerializeField] public List<GameObject> floorsToFlood;
    [SerializeField] public EndGame endGame;
    [SerializeField] TMP_Text decksRemainingText;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FloodFloor(int whichFloor)
    {
        areFloorsFlooded[whichFloor] = true;
        AnimateFloorFlooding(whichFloor);
        CheckEndOfGame();
    }

    void CheckEndOfGame()
    {
        int floodedFloorsCount = 0;

        foreach (bool floor in areFloorsFlooded)
        {
            if (floor == true)
            {
                floodedFloorsCount += 1;
            }
        }

        // Display how many decks remaining in the HUD UI
        int remainingDecks = 3 - floodedFloorsCount;
        decksRemainingText.text = "Decks Remaining: " + remainingDecks.ToString();

        if (floodedFloorsCount >= 3)
        {
            endGame.EndTheGame();
        }
    }

    void AnimateFloorFlooding(int whichFloor)
    {
        floorsToFlood[whichFloor].GetComponent<Animator>().SetBool("isFlooded", true);
        
    }

}
