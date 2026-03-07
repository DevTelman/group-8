using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    // Այս ֆունկցիան ընտրիր OnClick-ի ցուցակից
    public void RestartGame()
    {
        Time.timeScale = 1f;

        if (GameManager.instance != null)
        {
            GameManager.instance.currentLevelStars = 0;
            GameManager.instance.currentLevelGarbage = 0;
        }

        if (MusicManager.Instance != null && MusicManager.Instance.audioSource != null)
        {
            MusicManager.Instance.audioSource.Stop();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
