using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEscalation : MonoBehaviour
{
    private EndGame endgame;
    public NewSpawnScript leakSpawner;

    // Start is called before the first frame update
    void Start()
    {
        endgame = FindObjectOfType<EndGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (endgame.secondsSurvived < 20f)
        {
            leakSpawner.spawnTime = 5f;
        } else if (endgame.secondsSurvived < 40f)
        {
            leakSpawner.spawnTime = 4f;
        } else if (endgame.secondsSurvived < 60f)
        {
            leakSpawner.spawnTime = 3f;
        }
        else if (endgame.secondsSurvived < 80f)
        {
            leakSpawner.spawnTime = 2f;
        }
        else if (endgame.secondsSurvived < 100f)
        {
            leakSpawner.spawnTime = 1f;
        }
        else if (endgame.secondsSurvived < 120f)
        {
            leakSpawner.spawnTime = 0.5f;
        }
    }
}
