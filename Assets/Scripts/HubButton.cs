using UnityEngine;
using UnityEngine.SceneManagement;

public class HubButton : MonoBehaviour
{
    // Այս ֆունկցիան կկապվի Button-ի OnClick իրադարձության հետ
    public void GoToHubScene()
    {
        SceneManager.LoadScene(4); // Բեռնում է 4-րդ սցենան
    }
}
