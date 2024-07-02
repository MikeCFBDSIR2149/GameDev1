using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter1 : MonoBehaviour
{
    public Transform backDoor;

    public bool isDoor = false;
    public bool isOver = false;
    public bool isopen = true;
    public GameObject ground1;
    public GameObject cube1;
    public GameObject cube2;
    private Transform playerTransform;
    public ThirdPersonController ground;
  
    private void Start()
    {
        ground = GameObject.Find("RobotKyle").GetComponent<ThirdPersonController>();
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
        if (isopen)
        {
            if (Input.GetKeyDown(KeyCode.L) && PickUI.entersome >= 0)
            {
                isopen = true;
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
        // 碰撞到的对象是玩家
        ground.Grounded = true;
        ground.MoveGround = true;
        isDoor = true;
        isOver = true;
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player")) // 碰撞到的对象是玩家
        {
            isDoor = false;
        }
    }
}
