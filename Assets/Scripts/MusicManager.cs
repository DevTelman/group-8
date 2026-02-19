using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneAudio
{
    public int sceneIndex;
    public AudioClip audioClip;
    public bool waitForCountdown = false;
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSource;
    public List<SceneAudio> sceneAudios;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (var item in sceneAudios)
        {
            if (item.sceneIndex == scene.buildIndex)
            {
                audioSource.clip = item.audioClip;

                if (!item.waitForCountdown)
                {
                    audioSource.Play();
                }

                break;
            }
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null)
            return;

        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayMusicBySceneIndex(int sceneIndex)
    {
        foreach (var item in sceneAudios)
        {
            if (item.sceneIndex == sceneIndex)
            {
                if (audioSource.clip != item.audioClip)
                {
                    audioSource.clip = item.audioClip;
                    audioSource.Play();
                }
                return;
            }
        }
    }
}
