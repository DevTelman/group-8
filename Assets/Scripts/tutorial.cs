using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoToTutorialScene()
    {
        SceneManager.LoadScene(1);
    }
}
