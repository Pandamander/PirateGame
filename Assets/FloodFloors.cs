using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFloors : MonoBehaviour
{
    public List<bool> areFloorsFlooded;
    [SerializeField] public List<GameObject> floorsToFlood;

    // Start is called before the first frame update

    void Start()
    {
        AnimateFloorFlooding(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FloodFloor(int whichFloor)
    {
        areFloorsFlooded[whichFloor] = true;
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

        if (floodedFloorsCount >= 3)
        {
            EndGame();
        }
    }

    void AnimateFloorFlooding(int whichFloor)
    {
        floorsToFlood[whichFloor].GetComponent<Animator>().SetBool("isFlooded", true);
    }

    void EndGame()
    {
        // Move over the end the game functions
    }
}
