using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box4Hit : MonoBehaviour
{

    private int maxCount = 4;
    private int currentCount = 0;
    public GameObject box;
    //public Animator animator;
    //public float delay = 0f;

    private void Start()
    {
        currentCount = 0;
    }

    private void OnTriggerEnter(Collider col)
    {
        playerMovement player = col.GetComponent<playerMovement>();        

        if (col.CompareTag("Player"))
        {
            player.Jump();
            currentCount++;            

            if (currentCount < maxCount)
            {
                //animator.SetBool("BoxAnim", true);                
                GameManager.Instance.apples += Random.Range(1, 3);
            }

            if (currentCount == maxCount)
            {
                //animator.SetBool("BoxAnim", true);
                Destroy(box);
                GameManager.Instance.apples += Random.Range(1, 3);                
                GameManager.Instance.boxes++;                
            }
        } 
    }
}
