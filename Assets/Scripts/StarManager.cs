using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Image[] starIcons; // 3 UI աստղերը
    private int collectedStars = 0;

    void Start()
    {
        // Սկզբում բոլորը անջատված
        foreach (Image img in starIcons)
        {
            img.enabled = false;
        }
    }

    public void CollectStar()
    {
        if (collectedStars >= starIcons.Length)
            return;

        starIcons[collectedStars].enabled = true; // UI աստղը երևում է
        collectedStars++;
    }
}
