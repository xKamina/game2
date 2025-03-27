using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float jumpForce = 2f;
    

    private void OnTriggerEnter(Collider player)
    {
        playerMovement controller = player.GetComponent<playerMovement>();

        if (player.CompareTag("Player"))
        {
            controller.jumpHeight += jumpForce;
            Destroy(gameObject);
        }
    }
}
