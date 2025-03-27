using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    private int maxCount = 4;
    private int currentCount = 0;    

    private void Start()
    {
        currentCount = 0;
    }

    //-----------------Trigger-----------------
    void OnTriggerEnter(Collider other)
    {
        playerMovement player = GetComponent<playerMovement>();

        if (other.gameObject.CompareTag("DeathLayer"))
        {
            GameManager.Instance.LoseLife(1);
            GameManager.Instance.apples = 0;

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = player.lastCheckpointPosition;
            GetComponent<CharacterController>().enabled = true;
        }    
      
        if (other.gameObject.CompareTag("Trigger"))
        {
            player.Jump();
            Destroy(other.transform.parent.gameObject);
            GameManager.Instance.apples += Random.Range(1, 4);
            GameManager.Instance.boxes++;                    
        }

        if (other.gameObject.CompareTag("TopBoxTrigger"))
        {            
            Destroy(other.transform.parent.gameObject);
            GameManager.Instance.apples += Random.Range(1, 4);
            GameManager.Instance.boxes++;
        }

        if (other.gameObject.CompareTag("FourTrigger"))
        {
            player.Jump();
            currentCount++;

            if (currentCount < maxCount)
            {                                
                GameManager.Instance.apples += Random.Range(1, 3);
            }

            if (currentCount == maxCount)
            {                
                Destroy(other.transform.parent.gameObject);
                GameManager.Instance.apples += Random.Range(1, 3);
                GameManager.Instance.boxes++;
                currentCount = 0;
            }
        }

        if (other.gameObject.CompareTag("CheckpointTrigger"))
        {
            player.Jump();
            Destroy(other.transform.parent.gameObject);
            GameManager.Instance.boxes++;
            player.lastCheckpointPosition = transform.position;
        }        
    }

    //-----------------Collision-----------------

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        playerMovement player = GetComponent<playerMovement>();
        
        if (hit.gameObject.tag == "BoxCol" && !player.canAttack && player.isGrounded)
        {
            Destroy(hit.transform.parent.gameObject);
            player.canAttack = true;
            GameManager.Instance.apples += Random.Range(1, 4);
            GameManager.Instance.boxes++;                               
        }

        if (hit.gameObject.tag == "CheckpointCol" && !player.canAttack && player.isGrounded)
        {
            Destroy(hit.transform.parent.gameObject);
            GameManager.Instance.boxes++;
            player.lastCheckpointPosition = transform.position;

        }
    }
    
}
