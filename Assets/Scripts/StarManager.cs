using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Image[] starIcons;
    private int collectedCount = 0;

    void Start()
    {
        foreach (Image img in starIcons)
        {
            img.enabled = false;
        }
    }

    public void CollectStar()
    {
        if (collectedCount < starIcons.Length)
        {
            starIcons[collectedCount].enabled = true;
            collectedCount++;
        }
    }
}
