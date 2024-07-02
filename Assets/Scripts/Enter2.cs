using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform backDoor;
     
         public bool isDoor = false;
         public bool isOver = false;
         public bool isopened = false;
         public GameObject ground1;
         public GameObject cube1;
         public GameObject cube2;
         private Transform playerTransform;
 
       
         private void Start()
         {
             playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
         }
     
         private void Update()
         {
             if (isDoor || isOver)
             {
                 
                     if (Input.GetKeyDown(KeyCode.J))
                     {
                         playerTransform.position = backDoor.position;
                         isOver = false;
                         ground1.SetActive(true);
     
                     }
                 }
             if (isopened)
             {
                 if (Input.GetKeyDown(KeyCode.L) && PickUI.entersome >= 0)
                 {
                     isopened = true;
                     PickUI.entersome -= 1;
                     cube1.SetActive(false);
                     cube2.SetActive(true);
                 }
             }
            
     
     
     
         }
     
     
     
         private void OnTriggerEnter(Collider player)
         {
             if (!player.CompareTag("Player"))
                 return;
             isDoor = true;
             isOver = true;
             isopened = true;
         }
         private void OnTriggerExit(Collider player)
         {
             if (player.CompareTag("Player"))
             {
                 isDoor = false;
             }
         }
}
