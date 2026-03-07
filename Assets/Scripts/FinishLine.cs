using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel; // Այստեղ գցիր քո Win Panel-ը Inspector-ից

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ստուգում ենք՝ արդյոք Player-ն է հասել վերջնակետին
        if (collision.CompareTag("Player"))
        {
            Win();
        }
    }

    void Win()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LevelWon();
        }

        Time.timeScale = 0f;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
}
