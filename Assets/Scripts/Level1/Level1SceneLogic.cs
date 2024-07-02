using System.Collections;
using UnityEngine;

public class Level1SceneLogic : MonoBehaviour
{
    public GameObject levelTip;
    
    private void Start()
    {
        StartCoroutine(ShowLevel());
    }

    private IEnumerator ShowLevel()
    {
        levelTip.SetActive(true);
        yield return new WaitForSeconds(2f);
        levelTip.SetActive(false);
    }
}
