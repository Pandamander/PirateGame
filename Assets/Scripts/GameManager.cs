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
Make the ItemPickup script detect collision
Make pickup destroy the item and give it to you
Make it so that when you throw harpoon, it checks if you hve a harpoon, and removes it
implement your own item pickup script on the harpoon
Translate new spawning system to the cracks

NEXT UP:
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