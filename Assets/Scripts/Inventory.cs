using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();
    public int inventoryCap = 100;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }

        instance = this;
    }

    public bool Add(Item item)
    {
        if (items.Count < inventoryCap)
        {
            items.Add(item);
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}