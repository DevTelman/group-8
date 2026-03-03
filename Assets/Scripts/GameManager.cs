using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalStars = 0;
    public int totalGarbage = 0;

    [Header("Current Level Scores")]
    public int currentLevelStars = 0;
    public int currentLevelGarbage = 0;

    private TMP_Text levelGarbageText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData(); // Բեռնում ենք պահպանված տվյալները
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f; // Համոզվում ենք, որ խաղը կանգնած չէ
        currentLevelStars = 0;
        currentLevelGarbage = 0;
        FindUITexts();
        UpdateUI();
    }

    private void FindUITexts()
    {
        // Լեվելի տեքստը
        GameObject garbageObj = GameObject.Find("LevelGarbage");
        if (garbageObj != null)
            levelGarbageText = garbageObj.GetComponent<TMP_Text>();

        // Մենյուի տեքստերը
        GameObject totalStarObj = GameObject.Find("TotalStarsText");
        GameObject totalGarbageObj = GameObject.Find("TotalGarbageText");

        if (totalStarObj != null)
            totalStarObj.GetComponent<TMP_Text>().text = totalStars.ToString();
        if (totalGarbageObj != null)
            totalGarbageObj.GetComponent<TMP_Text>().text = totalGarbage.ToString();
    }

    public void AddStar()
    {
        currentLevelStars++;
    }

    public void AddGarbage()
    {
        currentLevelGarbage++;
        UpdateUI();
    }

    public void LevelWon()
    {
        totalStars += currentLevelStars;
        totalGarbage += currentLevelGarbage;
        SaveData(); // Պահպանում ենք հաղթելուց հետո
    }

    public void UpdateUI()
    {
        if (levelGarbageText != null)
            levelGarbageText.text = currentLevelGarbage.ToString();
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("TotalStars", totalStars);
        PlayerPrefs.SetInt("TotalGarbage", totalGarbage);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        totalStars = PlayerPrefs.GetInt("TotalStars", 0);
        totalGarbage = PlayerPrefs.GetInt("TotalGarbage", 0);
    }
}
