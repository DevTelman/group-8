using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.LevelWon(); // Միայն հիմա է գումարվում ընդհանուրին
            }

            Time.timeScale = 0f;
            if (winPanel != null)
                winPanel.SetActive(true);
        }
    }
}
