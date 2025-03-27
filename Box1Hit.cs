using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Hit : MonoBehaviour
{
    public GameObject box;
    //public Animator animator;
    //public float delay = 0f;
    
    private void OnTriggerEnter(Collider col)
    {
        playerMovement player = col.GetComponent<playerMovement>();         

        if (col.CompareTag("Player"))
        {
            player.Jump();
            //animator.SetBool("BoxAnim", true);
            Destroy(box);
            GameManager.Instance.apples += Random.Range(1, 4);
            GameManager.Instance.boxes++;            
        }
        
    }
}
