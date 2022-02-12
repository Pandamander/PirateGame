using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakSpawnPoint : MonoBehaviour
{
    public bool isOccupied;
    public bool isValid;
    [SerializeField] public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        isOccupied = true;
    }
}
