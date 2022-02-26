using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int opensRemaining = 20; // Make sure this is set to the same value as the health bar
    public int howMuchMoney = 500;
    public HealthBar healthBar;
    [SerializeField] public EndGame endGame;
    [SerializeField] AudioSource audioSource;

    public GameObject tooltipSpacebar;
    private Vector3 tooltipOffset = new Vector3(-1.4f, .9f, 0);

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(opensRemaining);
        healthBar.SetHealth(opensRemaining);
        endGame = FindObjectOfType<EndGame>();

        // instantiate tooltip if a tooltip has been provided
        // the reason to instantiate vs use a child object is so the tooltip doesn't inherit rotation values from the ship
        if (tooltipSpacebar != null)
        {
            tooltipSpacebar = Instantiate(tooltipSpacebar, transform.position + tooltipOffset, Quaternion.identity);
            tooltipSpacebar.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // tooltip positioning
        tooltipSpacebar.transform.position = transform.position + tooltipOffset;
    }

    public void PickLock()
    {
        // Debug.Log("Opens" + opensRemaining);
        opensRemaining -= 1;

        healthBar.gameObject.SetActive(true);
        healthBar.SetHealth(opensRemaining);

        if (opensRemaining <= 0)
        {
            OpenTreasure();
        }
    }

    private void OpenTreasure()
    {
        FindObjectOfType<OpenTreasure>().TreasureIsOpened();
        endGame.GetMoney(howMuchMoney);
        audioSource.Play(); // I thnk this doesn't work because the object gets destroyed
        
        Destroy(gameObject);
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
        }
    }
}
