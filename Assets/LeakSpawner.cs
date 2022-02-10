using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakSpawner : MonoBehaviour
{
    public int numberOfLeaks = 0;
    [SerializeField] GameObject ship;
    [SerializeField] float sinkingSpeed = 0.001f;
    [SerializeField] float resurfaceSpeed = 0.0005f;
    [SerializeField] float leakFrequency = 10f;
    [SerializeField] GameObject topOfWater;
    [SerializeField] GameObject topOfShip;
    [SerializeField] GameObject highestLeak;
    [SerializeField] GameObject pointOfNoReturn;
    [SerializeField] Leak myLeak;
    [SerializeField] GameObject[] leakSpawnPoints;
    float leakCounter = 0f;

    // Start is called before the first frame update
    void Update()
    {
        leakCounter += 0.01f;
        if (leakCounter > leakFrequency)
        {
            leakCounter = 0f;
            SpawnLeak();
        }
    }


    void SpawnLeak()
    {

        // Make it so that it picks a random gameobject in LeakSpawnPOints tok place the spot
        int selectedSpawnPoint = Random.Range(0, leakSpawnPoints.Length);
        if (leakSpawnPoints[selectedSpawnPoint].transform.position.y > topOfWater.transform.position.y) // if it's above water, make the leak
        {
            Debug.Log("Selected " + selectedSpawnPoint + " at " + leakSpawnPoints[selectedSpawnPoint].transform.position);

            numberOfLeaks += 1;

            var newLeak = Instantiate(myLeak, leakSpawnPoints[selectedSpawnPoint].transform.position, Quaternion.identity);
            newLeak.transform.parent = gameObject.transform;

            FindObjectOfType<CameraShake>().ShakeCamera(2f, 2f);
        }

        
    }

    public void CheckSinkShip()
    {
        // make it so that if the hole is below the water, it doesn't keep sinking that much
        if (numberOfLeaks > 0)
        {
            SinkTheShip();
        }

        if (pointOfNoReturn.transform.position.y < topOfWater.transform.position.y)
        {
            SinkTheShip();
        }
    }

    private void SinkTheShip()
    {
        ship.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y - (1f * sinkingSpeed), ship.transform.position.z);
    }

    public void RemoveLeak()
    {
        numberOfLeaks -= 1;
    }
}

/*

Leak Spawner
- Makes a leak - DONE
- Keeps track of how many leaks there are - DONE
- Makes the ship go down - DONE
- If the ship is totally submerged, game over

Leak
- Has repairTime remaining - DONE
- When repairTime = 0, repairs itself, tells the leak spawner that there is 1 less - DONE

Repair (on Player Object)
- Same method as Ladder, can call repair function on the leak (the trigger) - DONE
- Make leaks appear around random locations


 */