using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrushCheck : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingPlatform"))
            playerMovement.isCrushed = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingPlatform"))
            playerMovement.isCrushed = false;
    }
}