using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioClip music1; // 音乐1
    public AudioClip music2; // 音乐2
    private AudioSource audioSource;

    private static AudioController instance = null;

    private void Awake()
    {
        // 确保只有一个实例存在
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 监听场景加载事件
        PlayMusic(music1);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Start" || scene.name == "Main")
        {
            PlayMusic(music1);
        }
        else if (scene.name == "Level 0" || scene.name == "Level 1" || scene.name == "Level 2")
        {
            PlayMusic(music2);
        }
    }

    private void PlayMusic(AudioClip music)
    {
        if (audioSource.clip == music) 
            return;
        audioSource.clip = music;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 移除场景加载监听
    }
}
