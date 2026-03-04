using UnityEngine;
using UnityEngine.SceneManagement;

public class TheHubChanger : MonoBehaviour
{
    [Header("Settings")]
    public int hubSceneIndex = 4;
    public int currentLevelNumber;

    public void GoToHubAndEvolve()
    {
        PlayerPrefs.SetInt("NeedsEvolve", 1);

        int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

        if (currentLevelNumber >= reachedLevel)
        {
            PlayerPrefs.SetInt("ReachedLevel", currentLevelNumber + 1);
        }

        PlayerPrefs.Save();

        SceneManager.LoadScene(hubSceneIndex);
    }
}
