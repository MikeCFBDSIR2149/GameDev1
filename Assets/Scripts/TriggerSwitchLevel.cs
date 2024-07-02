using UnityEngine;

public class TriggerSwitchLevel : MonoBehaviour
{
    public GameObject gameLogic;
    
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player")) // 碰撞到的对象是玩家
        {
            gameLogic.GetComponent<GameLogicController>().SwitchToNextScene();
        }
    }
}
