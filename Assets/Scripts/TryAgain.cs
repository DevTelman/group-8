using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;

        // Ուղղակի զրոյացնում ենք ընթացիկ հաշիվը ու վերսկսում
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetLevelData();
        }

        if (MusicManager.Instance != null && MusicManager.Instance.audioSource != null)
        {
            MusicManager.Instance.audioSource.Stop();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
