using UnityEngine;
using UnityEngine.SceneManagement; // Մտնում է SceneManager-ի համար

public class HomeButton : MonoBehaviour
{
    public void GoToHomeScene()
    {
        SceneManager.LoadScene(0);
    }
}
