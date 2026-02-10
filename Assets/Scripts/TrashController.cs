using TMPro;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public int collectedStars = 0;
    public TMP_Text starsText;

    private void Start()
    {
        UpdateStarsUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Garbage"))
        {
            collectedStars++;
            UpdateStarsUI();
            Destroy(collision.gameObject);
        }
    }

    void UpdateStarsUI()
    {
        starsText.text =""+ collectedStars;
    }
}
