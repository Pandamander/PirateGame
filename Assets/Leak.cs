using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour
{
    [SerializeField] GameObject topOfWater;
    [SerializeField] float waterBuffer = 0.1f;
    public HealthBar healthBar;
    int repairsRemaining = 5;

    // Start is called before the first frame update
    void Awake()
    {
        topOfWater = GameObject.Find("TopOfWater");
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < topOfWater.transform.position.y - waterBuffer) // if the leak is underwater, you can't fix it. So remove it
        {
            PatchLeak();
            Debug.Log("Leak under water! Patching!");
        }
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
        FindObjectOfType<LeakSpawner>().RemoveLeak();
        FindObjectOfType<Repair>().RemoveLeak();
        Debug.Log("Patched leak!");
        Destroy(gameObject);
    }
}
