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
        // LeadSpawner sinks the ship
        
    }


}



/*
DONE:
Make camera pan up and down
Fix ladders -
Fix jumping
Finalize the leak breaking code so that it's properly counting levels

NEXT UP:

Make the stages hae different sprites
Make the final stage break the floor
Have a collection of floors

Make it so that the cracks time out, fill the floors, then you lose

Put the Solver and the child emitter on each leak
Then when leak is spawned, pass the emitter into the Obi Fluid Renderer on the Camera


5:22 - scritable object data setup

Add the camera shake again



P2 IDEAS:
Get a hammer that lets you repair faster
Other pirates attacking, shooting cannonballs
Skeletons
Big and small leaks

BUG: Jumping animation doesn't work. Maybe make your own movement system?

 */