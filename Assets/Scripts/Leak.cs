using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour
{
    [SerializeField] float waterBuffer = 0.1f;
    public SpriteRenderer sprite;
    public Sprite[] stageSprites;
    public HealthBar healthBar;
    int repairsRemaining = 5;
    public int leakStage = 0;
    public int finalLeakStage = 4;
    public float stageDuration = 5f;
    public float stageCounter = 0f;
    public bool stopCounting = false;

    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.gameObject.SetActive(false);
        SetLeakVisual(leakStage);
    }

    // Update is called once per frame
    void Update()
    {
        // This make the leaks progress through the stages and then crack
        if (stopCounting == false)
        {
            if (leakStage < finalLeakStage)
            {
                stageCounter += Time.deltaTime;

                if (stageCounter >= stageDuration) // if time to go to next stage
                {
                    stageCounter = 0f;
                    leakStage += 1;
                    SetLeakVisual(leakStage);
                }
            }
            else
            {
                LeakBreaks();
                stopCounting = true;
            }
        }
        

        
        /*
        // This old code was used when the ship sank based on the leak being present
        if (transform.position.y < topOfWater.transform.position.y - waterBuffer) // if the leak is underwater, you can't fix it. So remove it
        {
            PatchLeak();
            Debug.Log("Leak under water! Patching!");
        }
        */
    }

    void SetLeakVisual(int whichStage)
    {
        switch (whichStage)
        {
            case 0:
                sprite.sprite = stageSprites[0];
                break;

            case 1:
                sprite.sprite = stageSprites[1];
                break;

            case 2:
                sprite.sprite = stageSprites[2];
                break;

            case 3:
                sprite.sprite = stageSprites[3];
                break;
        }
    }

    void LeakBreaks()
    {
        Debug.Log("The leak has broken!!!!");
    }

    public void RepairLeak()
    {
        Debug.Log("Reparing, " + repairsRemaining + " repairs left");
        repairsRemaining -= 1;

        healthBar.gameObject.SetActive(true);
        healthBar.SetHealth(repairsRemaining);

        if (repairsRemaining <= 0)
        {
            PatchLeak();
        }
    }

    private void PatchLeak()
    {
        //FindObjectOfType<LeakSpawner>().RemoveLeak();
        GetComponent<SpawnableObject>().RemoveSpawnedObject();
        FindObjectOfType<Repair>().RemoveLeak();
        Debug.Log("Patched leak!");
        Destroy(gameObject);
    }
}
