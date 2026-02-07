using UnityEngine;
using UnityEngine.SceneManagement;

public static class AutoStartScene
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void LoadStartScene()
    {
        int startSceneIndex = 0;
        if (SceneManager.GetActiveScene().buildIndex != startSceneIndex)
        {
            SceneManager.LoadScene(startSceneIndex);
        }
    }
}
