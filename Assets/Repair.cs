using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    private bool isRepairingLeak;
    Collider2D hole;

    private void Update()
    {
        if (isRepairingLeak)
        {
            //isRepairing = true;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                hole.GetComponent<Leak>().RepairLeak();
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Leak"))
        {
            isRepairingLeak = true;
            hole = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Leak"))
        {
            isRepairingLeak = false;
            hole = null;
        }
    }

    public void RemoveLeak()
    {
        hole = null;
    }
}
