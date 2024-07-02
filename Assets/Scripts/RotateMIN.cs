using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMIN : MonoBehaviour
{
    public bool isDoor = false;
   
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
                playerTransform.Rotate(0, 0, 0);
                
            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (!player.CompareTag("Player"))
            return;
        // 碰撞到的对象是玩家
        isDoor = true;
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player")) // 碰撞到的对象是玩家
        {
            isDoor = false;
        }
    }
}
