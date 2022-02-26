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

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(opensRemaining);
        healthBar.SetHealth(opensRemaining);
        endGame = FindObjectOfType<EndGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
