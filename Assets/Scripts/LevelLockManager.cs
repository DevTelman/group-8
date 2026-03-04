using UnityEngine;
using UnityEngine.UI;

public class LevelLockManager : MonoBehaviour
{
    [Header("Level Buttons")]
    public Button level2Button;
    public Button bossLevelButton;

    [Header("Locked Visuals")]
    public Color lockedColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    void Start()
    {
        int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

        if (reachedLevel < 2)
        {
            SetButtonLocked(level2Button);
        }

        if (reachedLevel < 3)
        {
            SetButtonLocked(bossLevelButton);
        }
    }

    void SetButtonLocked(Button btn)
    {
        if (btn != null)
        {
            btn.interactable = false;

            Image btnImage = btn.GetComponent<Image>();
            if (btnImage != null)
            {
                btnImage.color = lockedColor;
            }
        }
    }
}
