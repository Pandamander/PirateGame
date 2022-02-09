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
let you restart - DONE
Figure out why the repair stopped working - DONE
Send to coop - DONE


NEXT UP:


Give you a score
Collect treasure
Make it so that the same leak doesn't appear in the same spot
Give the leaks health bars


Make the ship bobbing still work while the ship is going down
Make some animation for the reparining
Make it so you can bob and swim in the water

Cooper's feedback:
Speed up character walking



Camera shake when a new hole appears
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