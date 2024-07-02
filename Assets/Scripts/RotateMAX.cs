using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMAX : MonoBehaviour
{
    public static bool start;
    public bool isDoor = false;
    public GameObject player;
    public GameObject ground;
    public GameObject cube;
    public GameObject cube1;
    public GameObject ground1;
    public float rotateSpeed;  
    public float rotateSpeedq=3.0f;

    private Transform playerTransform;
    
    private void Start()
    {
   
        playerTransform = GameObject.FindGameObjectWithTag("Chuan").GetComponent<Transform>();
        
    }

    private void Update()
    {
    
        
        if (isDoor)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                start = true;
                ground.SetActive(false);
                ground1.SetActive(true);

            }

            
        }
        if (start)
        {
            rotateSpeedq -= Time.deltaTime;     
            switch (rotateSpeedq)
            {
                case > 0:
                    player.SetActive(false);
                    cube.transform.Rotate(-rotateSpeed * Time.deltaTime,0,0);
                    break;
                case < 0:
                    player.SetActive(true);
                    break;
            }

            if (rotateSpeedq < -3)
            {
                cube1.SetActive(false);
                start = false;
            }
                
        }
        
    }

    private void OnTriggerEnter(Collider ob)
    {
        if (!ob.CompareTag("Player"))
            return;
        // 碰撞到的对象是玩家
    isDoor = true;
    }
    
    private void OnTriggerExit(Collider ob)
    {
        if (ob.CompareTag("Player")) // 碰撞到的对象是玩家
        {
            isDoor = false;
        }
    }
    
}
