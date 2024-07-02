using System.Collections;
using UnityEngine;

public class Level0SceneLogic : MonoBehaviour
{
    public float fadeInTime; // 淡入时间

    public CanvasGroup canvasGroup;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;

    public GameObject ground1;
    public GameObject ground2;
    public GameObject ground3;
    public GameObject ground4;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;

    public GameObject flashStopButton;
    public GameObject flashStartButton;

    public MeshRenderer planeMaterial;
    public Material woodDefault;
    public Material woodFlash;
    public float flashDuration; // 闪烁的持续时间

    private IEnumerator flash;

    private void Awake()
    {
        flash = FlashCoroutine();
    }

    private void Start()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);
        panel6.SetActive(false);
        panel7.SetActive(false);
        panel8.SetActive(false);
        ground1.SetActive(true);
        planeMaterial.material = woodDefault;
        canvasGroup.alpha = 0.1f;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float time = 0f;
        while (time < fadeInTime)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0.1f, 1, time / fadeInTime);
            yield return null;
        }
    }

    public void Panel1toPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void Panel2toPanel3()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    
    public void Panel3toPanel4()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }
    
    public void Panel4toPanel5()
    {
        panel4.SetActive(false);
        panel5.SetActive(true);
        StartFlash();
        flashStartButton.SetActive(false);
        flashStopButton.SetActive(true);
    }
    public void Panel5toPanel6()
    {
        StopCoroutine(flash);
        planeMaterial.material = woodDefault;
        cube1.SetActive(true);
        panel5.SetActive(false);
        panel6.SetActive(true);
    }
    public void Panel6toPanel7()
    {
        panel6.SetActive(false);
        panel7.SetActive(true);
        cube2.SetActive(true);
        cube3.SetActive(true);
    }

    public void StartFlash()
    {
        StartCoroutine(flash);
        flashStartButton.SetActive(false);
        flashStopButton.SetActive(true);
    }

    public void StopFlash()
    {
        StopCoroutine(flash);
        planeMaterial.material = woodDefault;
        flashStartButton.SetActive(true);
        flashStopButton.SetActive(false);
    }
    
    private IEnumerator FlashCoroutine()
    {
        while (true)
        {
            // 设置高亮颜色
            planeMaterial.material = woodFlash;
            // 等待一段时间
            yield return new WaitForSeconds(flashDuration);

            // 恢复原始颜色
            planeMaterial.material = woodDefault;
            // 等待一段时间
            yield return new WaitForSeconds(flashDuration);
        }
        // ReSharper disable once IteratorNeverReturns
    }
    
    public void SwitchToLevel1()
    {
        planeMaterial.material = woodDefault;
        panel7.SetActive(false);
        panel8.SetActive(true);
        cube4.SetActive(true);
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
    }
}
