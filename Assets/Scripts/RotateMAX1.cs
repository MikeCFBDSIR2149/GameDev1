using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class RotateMAX1 : MonoBehaviour
{
    public float rotateSpeed;  
    public float rotateSpeedq = 3.0f;

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
                cube1.SetActive(true);
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
                game.transform.Rotate(-rotateSpeed*Time.deltaTime,0,0);
                
            }

            if (rotateSpeedq < 0)
            {
               
                game.transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
              
            }

            if (rotateSpeedq < -3)
            {
                player.SetActive(true);
                start = false;
            }
                
        }
    }
    // Update is called once per frame

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
