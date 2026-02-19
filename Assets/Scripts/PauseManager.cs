using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject countdownCanvas;
    public AudioSource countdownAudio;
    public AudioClip PauseMusic;

    public void PauseGame()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(true);
        }

        Time.timeScale = 0f;

        if (countdownCanvas != null)
        {
            countdownCanvas.SetActive(false);
        }

        if (countdownAudio != null && countdownAudio.isPlaying)
        {
            countdownAudio.Pause();
        }

        MusicManager.Instance.PlayMusic(PauseMusic);
    }

    public void Resume()
    {
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        Time.timeScale = 1f;

        MusicManager.Instance.PlayMusicBySceneIndex(SceneManager.GetActiveScene().buildIndex);
    }
}
