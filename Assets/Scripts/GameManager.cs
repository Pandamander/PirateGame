using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LeakSpawner myLeakSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // LeadSpawner sinks the ship
        myLeakSpawner.CheckSinkShip();
    }


}



/*
DONE:
Make the ItemPickup script detect collision

NEXT UP:

Make pickup destroy the item and give it to you
Make it so that when you throw harpoon, it checks if you hve a harpoon, and removes it

implement your own item pickup script on the harpoon
Then, translate to the cracks as well

5:22 - scritable object data setup



Make the ship bobbing still work while the ship is going down
Make some animation for the reparining
Make it so you can bob and swim in the water

Cooper's feedback:
Speed up character walking




Make treasure that you can collect
Make water that you can swim in that goes up and down
Have you get stunned when you get hit, or when you die
Have levels, waves that you make it to, escalating chaos until you die


P2 IDEAS:
Get a hammer that lets you repair faster
Other pirates attacking, shooting cannonballs
Skeletons
Big and small leaks

BUG: Jumping animation doesn't work. Maybe make your own movement system?

 */