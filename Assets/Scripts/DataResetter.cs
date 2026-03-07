using UnityEngine;
using UnityEngine.SceneManagement;

public class DataResetter : MonoBehaviour
{
    public void ResetFullGameProgress()
    {
        // 1. Ջնջում ենք պահպանված ֆայլերը
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        // 2. Զրոյացնում ենք GameManager-ի մեջի ակտիվ թվերը
        if (GameManager.instance != null)
        {
            GameManager.instance.totalStars = 0;
            GameManager.instance.totalGarbage = 0;
            GameManager.instance.currentLevelStars = 0;
            GameManager.instance.currentLevelGarbage = 0;

            // Թարմացնում ենք UI-ը, որպեսզի անմիջապես 0 երևա
            GameManager.instance.UpdateTotalUI();
            GameManager.instance.UpdateUI();
        }

        Debug.Log("Ամբողջ խաղի առաջընթացը զրոյացվեց և փոփոխականները թարմացվեցին:");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
