using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopOneHitBox : MonoBehaviour
{
    public GameObject box;

    private void OnTriggerEnter(Collider col)
    {
        playerMovement player = col.GetComponent<playerMovement>();

        if (col.CompareTag("Player"))
        {            
            Destroy(box);
            GameManager.Instance.apples += Random.Range(1, 4);
            GameManager.Instance.boxes++;
        }
    }
}
