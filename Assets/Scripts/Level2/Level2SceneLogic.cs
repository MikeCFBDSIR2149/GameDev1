using System.Collections;
using UnityEngine;

public class Level2SceneLogic : MonoBehaviour
{
    public GameObject levelTip;
    public GameObject level2SpecialTip;
    
    private void Start()
    {
        level2SpecialTip.SetActive(true);
        StartCoroutine(ShowLevel());
    }

    private IEnumerator ShowLevel()
    {
        levelTip.SetActive(true);
        yield return new WaitForSeconds(2f);
        levelTip.SetActive(false);
    }
    
    public void CloseSpecialTip()
    {
        level2SpecialTip.SetActive(false);
    }
}
