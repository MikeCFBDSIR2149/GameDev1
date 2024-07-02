using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject gameOverUI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("DeathZone")) 
            return;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
