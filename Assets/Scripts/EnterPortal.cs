using StarterAssets;
using UnityEngine;

public class EnterPortal : MonoBehaviour
{

    public Transform backDoor;

    public bool isDoor = false;
    public bool isOver = false;
    public bool isopen = true;
    public GameObject cube1;
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
            if (isopen)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    playerTransform.position = backDoor.position;
                    isOver = false;
                }

               
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
