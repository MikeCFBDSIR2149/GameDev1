using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicController : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float FPS;
    private float timeCount;
    public float timeInterval;
    
    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
        if (!(timeCount >= timeInterval)) 
            return;
        FPS = 1 / Time.deltaTime;
        text.text = $"FPS: {FPS:F0}";
        timeCount = 0f;
    }

    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    
    public void BackToHome()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }
}
