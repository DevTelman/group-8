using UnityEngine;
using UnityEngine.SceneManagement;  // Մտնում է SceneManager-ի համար

public class HomeButton : MonoBehaviour
{
    // Այս ֆունկցիան կկապվի Button-ի OnClick իրադարձության հետ
    public void GoToHomeScene()
    {
        SceneManager.LoadScene(0); // Բեռնում է 0-րդ սցենան
    }
}
