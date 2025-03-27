using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject box;

    private void OnTriggerEnter(Collider col)
    {
        playerMovement player = col.GetComponent<playerMovement>();

        if (col.CompareTag("Player"))
        {
            player.Jump();
            player.lastCheckpointPosition = transform.position;
            Destroy(box);            
            GameManager.Instance.boxes++;
        }
    }
}
