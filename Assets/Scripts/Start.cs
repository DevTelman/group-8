using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public int sceneIndex = 1;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
