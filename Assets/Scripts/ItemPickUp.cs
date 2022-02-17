using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // This script is for items that you pick up

    public Item item;
    public bool alreadyTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (alreadyTriggered)
        { return; }

        alreadyTriggered = true;
        Debug.Log("Trigger " + collision.name);
        if(collision.gameObject.GetComponent<Player>())
        {
            PickUp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alreadyTriggered = false;
    }

    void PickUp()
    {
        Debug.Log("Picking up" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            GetComponent<SpawnableObject>().RemoveSpawnedObject(); // make sure this component is on the object
            Destroy(gameObject);
        }
        else
        {
            alreadyTriggered = false;
        }
        
    }
}
