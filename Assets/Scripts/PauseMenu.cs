using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject countdownCanvas;
    public AudioSource countdownAudio;
    public AudioSource backgroundMusic;

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

        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }
    }
}
