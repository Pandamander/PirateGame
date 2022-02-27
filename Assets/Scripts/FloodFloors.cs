using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FloodFloors : MonoBehaviour
{
    public List<bool> areFloorsFlooded;
    [SerializeField] public List<GameObject> floorsToFlood;
    [SerializeField] public List<Transform> floor0Transforms;
    [SerializeField] public List<Transform> floor1Transforms;
    [SerializeField] public List<Transform> floor2Transforms;
    [SerializeField] public EndGame endGame;
    [SerializeField] TMP_Text decksRemainingText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] public NewSpawnScript leakSpawner;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FloodFloor(int whichFloor) // The leaks call this if they run out of time
    {
        areFloorsFlooded[whichFloor] = true;
        AnimateFloorFlooding(whichFloor);

        RemoveSpawnPointsInFloodedArea();        

        

        
        CheckEndOfGame();
    }

    public void RemoveSpawnPointsInFloodedArea()
    {
        // This is a ugly hard coded method of removing the spawn points on flooded floors. Needs to be redone if we move leak span points
        if (areFloorsFlooded[0])
        {
            leakSpawner.possibleSpawns.Remove(floor0Transforms[0]);
            leakSpawner.possibleSpawns.Remove(floor0Transforms[1]);
            leakSpawner.possibleSpawns.Remove(floor0Transforms[2]);
            leakSpawner.possibleSpawns.Remove(floor0Transforms[3]);
            //List<car> result = GetSomeOtherList().Except(GetTheList()).ToList();
            //leakSpawner.spawnPoints.Remove(Transform t);
        }

        if (areFloorsFlooded[1])
        {
            leakSpawner.possibleSpawns.Remove(floor1Transforms[0]);
            leakSpawner.possibleSpawns.Remove(floor1Transforms[1]);
            leakSpawner.possibleSpawns.Remove(floor1Transforms[2]);
            leakSpawner.possibleSpawns.Remove(floor1Transforms[3]);
        }

        if (areFloorsFlooded[2])
        {
            leakSpawner.possibleSpawns.Remove(floor2Transforms[0]);
            leakSpawner.possibleSpawns.Remove(floor2Transforms[1]);
            leakSpawner.possibleSpawns.Remove(floor2Transforms[2]);
            leakSpawner.possibleSpawns.Remove(floor2Transforms[3]);

        }
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
        decksRemainingText.text = "Decks Remaining: " + remainingDecks.ToString() + "/3";

        if (floodedFloorsCount >= 3)
        {
            endGame.EndTheGame();
        }
    }

    void AnimateFloorFlooding(int whichFloor)
    {
        floorsToFlood[whichFloor].GetComponent<Animator>().SetBool("isFlooded", true);
        audioSource.Play();
        
    }

}
