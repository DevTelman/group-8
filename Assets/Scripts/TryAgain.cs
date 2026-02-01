using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
    public Button tryAgainButton;

    void Start()
    {
        if (tryAgainButton != null)
        {
            tryAgainButton.onClick.AddListener(RestartGame);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
