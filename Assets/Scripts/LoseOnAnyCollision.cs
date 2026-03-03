using UnityEngine;

public class LoseOnAnyCollision : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public string safeTag = "Safe";

    void Start()
    {
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(safeTag))
        {
            Win();
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    void Win()
    {
        GameManager.instance.LevelWon();
        winCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
