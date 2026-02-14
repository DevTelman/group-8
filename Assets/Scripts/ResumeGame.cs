using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioSource backgroundMusic;

    // Խաղը շարունակել
    public void Resume()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }

        Time.timeScale = 1f;

        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }
    }
}
