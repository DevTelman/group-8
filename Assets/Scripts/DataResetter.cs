using UnityEngine;
using UnityEngine.SceneManagement;

public class DataResetter : MonoBehaviour
{
    // Այս ֆունկցիան ջնջում է ԲՈԼՈՐ պահպանված տվյալները
    public void ResetFullGameProgress()
    {
        // Ջնջում է ամեն ինչ, ինչ պահվել է PlayerPrefs-ի մեջ
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Ամբողջ խաղի առաջընթացը զրոյացվեց:");

        // Վերաթարմացնում ենք ընթացիկ սցենան
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
