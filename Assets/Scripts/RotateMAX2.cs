using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMAX2 : MonoBehaviour
{ public float rotateSpeed;  
    public float rotateSpeedq=3.0f;

    public bool isDoor = false;
    public bool start;
    public GameObject cube;
    public GameObject game;
    public GameObject cube1;
    public GameObject player;
    public GameObject ground;
    public GameObject ground1;

    private void Update()
    {
        if (isDoor)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                cube.SetActive(false);
                ground.SetActive(false);
                ground1.SetActive(true);
                start = true;
                //director.Play();

            }
        }
        
        if (start)
        {
            rotateSpeedq -= Time.deltaTime;
            if (rotateSpeedq > 0)
            {
                player.SetActive(false);
                game.transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
                
            }

            if (rotateSpeedq < 0)
            {
                player.SetActive(true);
              
            }

            if (rotateSpeedq < -3)
            {
                start = false;
            }
                
        }
    }
    
    private void OnTriggerEnter(Collider player)
    {
        if (!player.CompareTag("Player"))
            return;
        isDoor = true;
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            isDoor = false;
        }
    }
}
