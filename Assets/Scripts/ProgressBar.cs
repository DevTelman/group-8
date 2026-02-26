using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform player;
    public float endX = 283.4864f;
    public Image fillImage;

    private float startX = 0f;

    void Start()
    {
        // Set initial fill
        fillImage.fillAmount = 0f;
    }

    void Update()
    {
        // Calculate distance traveled
        // Calculate progress (0 to 1)
        float progress = Mathf.Clamp01(player.position.x / endX);
        float roundedProgress = Mathf.Round(progress * 100f) / 100f;

        // Update fill amount
        fillImage.fillAmount = roundedProgress;
    }
}
