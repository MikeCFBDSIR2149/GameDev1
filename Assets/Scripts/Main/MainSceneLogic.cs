using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLogic : MonoBehaviour
{
    public void SwitchToLevel0()
    {
        SceneManager.LoadScene("Level 0");
    }
    
    public void SwitchToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void SwitchToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
}
