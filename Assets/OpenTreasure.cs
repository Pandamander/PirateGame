using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasure : MonoBehaviour
{
    private bool isOpeningTreasure;
    Collider2D treasureCollider;

    private void Update()
    {
        if (isOpeningTreasure)
        {
            //isRepairing = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {

                treasureCollider.GetComponent<Treasure>().PickLock();
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Treasure"))
        {
            isOpeningTreasure = true;
            treasureCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Treasure"))
        {
            isOpeningTreasure = false;
            treasureCollider = null;
        }
    }

    public void TreasureIsOpened()
    {
        treasureCollider = null;
    }
}
