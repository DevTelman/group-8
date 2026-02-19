using UnityEngine;

public class LoseOnAnyCollision : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winCanvas;

    public string safeTag = "Safe"; // tag, որի հետ բախվելիս GameOver չի լինի

    void Start()
    {
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Եթե բախված օբյեկտը ՉՈՒՆԻ safeTag
        if (!collision.gameObject.CompareTag(safeTag))
        {
            GameOver();
        }
        else
        {
            WinCanvas();
        }
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    void WinCanvas()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
