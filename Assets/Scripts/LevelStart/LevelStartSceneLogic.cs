using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartSceneLogic : MonoBehaviour
{
    public void SwitchToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
