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

    public GameObject tooltipWarning;
    public GameObject tooltipSpacebar;
    public BoxCollider2D tooltipTriggerCollider;
    private Vector3 tooltipOffset = new Vector3(-.5f, 1.3f, 0);

    // Start is called before the first frame update
    void Awake()
    {
        // First see if this floor is already flooded, and delete it if so
        SetFloor();
        //RemoveLeakIfFlooded();

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
        } else if (obiFluidRenderer.particleRenderers[3] == null)
        {
            openObiEmitterSlot = 3;
        }

        obiFluidRenderer.particleRenderers[openObiEmitterSlot] = myObiParticleRenderer;

        // instantiate tooltip if a tooltip has been provided
        // the reason to instantiate vs use a child object is so the tooltip doesn't inherit rotation values from the ship
        if (tooltipWarning != null)
        {
            tooltipWarning = Instantiate(tooltipWarning, transform.position + tooltipOffset, Quaternion.identity);
            StartCoroutine(Fader.FadeIn(tooltipWarning.GetComponent<SpriteRenderer>(), .2f)); // fade in the tooltip
        }

        if (tooltipSpacebar != null)
        {
            tooltipSpacebar = Instantiate(tooltipSpacebar, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            tooltipSpacebar.SetActive(false);
        }

        audioSource.Play();
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
        
        // tooltip positioning
        if (tooltipWarning != null)
        {
            tooltipWarning.transform.position = transform.position + tooltipOffset;
        }

        if (tooltipSpacebar != null)
        {
            tooltipSpacebar.transform.position = transform.position + new Vector3(0, 2, 0);
        }
        
        

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
        // Play SFX
        RemoveLeak();
    }

    private void RemoveLeak()
    {
        FindObjectOfType<FloodFloors>().RemoveSpawnPointsInFloodedArea();
        // Get rid of the leak if it wasn't a valid leak - no SFX, etc
        GetComponent<SpawnableObject>().RemoveSpawnedObject();
        FindObjectOfType<Repair>().RemoveLeak();
        obiFluidRenderer.particleRenderers[openObiEmitterSlot] = null; // Free up the emitter slot


        // get rid of stuff when the leak is patched
        if (tooltipWarning != null)
        {
            Destroy(tooltipWarning);
        }
        if (tooltipSpacebar != null)
        {
            Destroy(tooltipSpacebar);
        }
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

    private bool CheckIfFloorAlreadyFlooded()
    {
        // This checks to see if the floor is already flooded
        return FindObjectOfType<FloodFloors>().areFloorsFlooded[floorThisLeakIsOn];
    }

    private void RemoveLeakIfFlooded()
    {
        if (CheckIfFloorAlreadyFlooded())
        {
            Debug.Log("Removed leak on already flooded floor");
            RemoveLeak();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // make the tooltip appear and disappears when player is here
        if (collider.gameObject.GetComponent<Player>())
        {
            //Debug.Log("Trigger enter player");
            if (tooltipSpacebar != null)
            {
                tooltipSpacebar.SetActive(true);
            }

            if (tooltipWarning != null)
            {
                tooltipWarning.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // make the tooltip disappear
        if (collider.gameObject.GetComponent<Player>())
        {
            //Debug.Log("Trigger exit player");
            if (tooltipSpacebar != null)
            {
                tooltipSpacebar.SetActive(false);
            }

            if (tooltipWarning != null)
            {
                tooltipWarning.SetActive(true);
            }
        }
    }
}
