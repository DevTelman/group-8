using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel;
    private bool hasWon = false; // Որպեսզի երկու անգամ չաշխատի

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasWon && collision.CompareTag("Player"))
        {
            hasWon = true;
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
            winPanel.SetActive(true);
    }
}
