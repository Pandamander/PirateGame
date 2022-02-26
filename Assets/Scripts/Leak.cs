using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

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
    public ObiFluidRenderer obiFluidRenderer;
    public ObiParticleRenderer myObiParticleRenderer;
    private int openObiEmitterSlot = 0;
    public int floorThisLeakIsOn;

    private CameraShake cameraShake;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        SetFloor();

        /*
        // This is an attempt to make leaks not appear on floors that are already flooded. For some reason it creates nullRefAcceptions
        if (FindObjectOfType<FloodFloors>().areFloorsFlooded[floorThisLeakIsOn])
        {
            //Debug.Log("Despawned leak on floor " + floorThisLeakIsOn + ", already flooded");
            PatchLeak();
        }

        */
        


        cameraShake = FindObjectOfType<CameraShake>();

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.gameObject.SetActive(false);

        SetLeakVisual(leakStage);

        obiFluidRenderer = GameObject.FindObjectOfType<ObiFluidRenderer>(); // Get the main ObiRendeer on the camera
        myObiParticleRenderer = gameObject.GetComponentInChildren<ObiParticleRenderer>();

        if (obiFluidRenderer.particleRenderers[0] == null)
        {
            openObiEmitterSlot = 0;
        }
        else if (obiFluidRenderer.particleRenderers[1] == null)
        {
            openObiEmitterSlot = 1;
        } else if (obiFluidRenderer.particleRenderers[2] == null)
        {
            openObiEmitterSlot = 2;
        }

        obiFluidRenderer.particleRenderers[openObiEmitterSlot] = myObiParticleRenderer;

        audioSource.Play();
        //Set up what floor this is on. If the floor is already flooded, then don't create it
        

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
                PatchLeak();
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
                cameraShake.ShakeCamera(0.6f, 1.0f);
                break;

            case 1:
                sprite.sprite = stageSprites[1];
                cameraShake.ShakeCamera(0.8f, 2.0f);
                break;

            case 2:
                sprite.sprite = stageSprites[2];
                cameraShake.ShakeCamera(1.0f, 2.5f);
                break;

            case 3:
                sprite.sprite = stageSprites[3];
                cameraShake.ShakeCamera(1.2f, 3.0f);
                break;
        }
    }

    void LeakBreaks()
    {
        FindObjectOfType<FloodFloors>().FloodFloor(floorThisLeakIsOn);
    }

    public void RepairLeak()
    {
        // Debug.Log("Reparing, " + repairsRemaining + " repairs left");
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
        // Debug.Log("Patched leak!");

        obiFluidRenderer.particleRenderers[openObiEmitterSlot] = null; // Free up the emitter slot


        Destroy(gameObject);
    }

    private void SetFloor()
    {
        // This checks the height to see what floor it's on
        if (transform.position.y > 0.52)
        {
            floorThisLeakIsOn = 0;
        }
        else if (transform.position.y > -4.74)
        {
            floorThisLeakIsOn = 1;
        }
        else
        {
            floorThisLeakIsOn = 2;
        }
    }
}
