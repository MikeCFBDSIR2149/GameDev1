using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isDoor = false;

    private void Update()
    {
        if (isDoor)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                PickUI.entersome += 1;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            isDoor = true;
        }
    }
    
}
