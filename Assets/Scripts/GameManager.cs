using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // quit the game
            Application.Quit();
        }
        
    }


}




/*
 * 
 * 

DONE:
Make the timer stop if you lose
Pick up treasure
No more spawning on flooded floors
Make the reset button work


NEXT UP:
Sound FX
Fix the spawning of the leaks, for some reason they aren't getting rid of the old ones anymore in order. Should be FIFO
Fix lag if it becomes too much obi's
Make the ship sink if you lose
Add escalation: more rain, more rocking, more waves, more tentacles as time goes on
Random tips

 */