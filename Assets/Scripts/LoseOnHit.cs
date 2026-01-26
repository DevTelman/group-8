using UnityEngine;

public class LoseOnAnyCollision : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0.0001f;
    }
}
