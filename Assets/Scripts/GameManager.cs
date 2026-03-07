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

    private bool isLevelOver = false; // Թույլ չի տալիս կրկնակի հաշվարկ
    private TMP_Text levelGarbageText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;
        ResetLevelData(); // Ամեն անգամ լեվելը բացելիս զրոյացնում ենք
        FindUITexts();
        UpdateUI();
    }

    public void ResetLevelData()
    {
        currentLevelStars = 0;
        currentLevelGarbage = 0;
        isLevelOver = false;
    }

    private void FindUITexts()
    {
        GameObject garbageObj = GameObject.Find("LevelGarbage");
        if (garbageObj != null)
            levelGarbageText = garbageObj.GetComponent<TMP_Text>();

        UpdateTotalUI();
    }

    public void UpdateTotalUI()
    {
        GameObject totalStarObj = GameObject.Find("TotalStarsText");
        GameObject totalGarbageObj = GameObject.Find("TotalGarbageText");

        if (totalStarObj != null)
            totalStarObj.GetComponent<TMP_Text>().text = totalStars.ToString();
        if (totalGarbageObj != null)
            totalGarbageObj.GetComponent<TMP_Text>().text = totalGarbage.ToString();
    }

    public void AddStar()
    {
        if (!isLevelOver)
            currentLevelStars++;
    }

    public void AddGarbage()
    {
        if (!isLevelOver)
        {
            currentLevelGarbage++;
            UpdateUI();
        }
    }

    // Այս ֆունկցիան կանչվում է ՄԻԱՅՆ FinishLine-ի կողմից
    public void LevelWon()
    {
        if (isLevelOver)
            return; // Եթե արդեն հաշվել ենք, էլ չհաշվել

        isLevelOver = true;
        totalStars += currentLevelStars;
        totalGarbage += currentLevelGarbage;

        SaveData();
        UpdateTotalUI();
        Debug.Log("Level Saved! Total Stars: " + totalStars);
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
