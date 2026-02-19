using UnityEngine;
using UnityEngine.SceneManagement;

public class HubButton : MonoBehaviour
{
    public void GoToHubScene()
    {
        SceneManager.LoadScene(4);
    }
}
