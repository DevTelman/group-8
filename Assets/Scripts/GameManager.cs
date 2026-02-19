using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalStars = 0;
    public int totalGarbage = 0;

    public TMP_Text totalStarsText;
    public TMP_Text totalGarbageText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddStar()
    {
        totalStars++;
        UpdateUI();
    }

    public void AddGarbage()
    {
        totalGarbage++;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (totalStarsText != null)
            totalStarsText.text = totalStars.ToString();

        if (totalGarbageText != null)
            totalGarbageText.text = totalGarbage.ToString();
    }
}
