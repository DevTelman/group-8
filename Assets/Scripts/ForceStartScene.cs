using UnityEngine;
using UnityEngine.SceneManagement;

public static class AutoStartScene
{
    static void LoadStartScene()
    {
        int startSceneIndex = 0;
        if (SceneManager.GetActiveScene().buildIndex != startSceneIndex)
        {
            SceneManager.LoadScene(startSceneIndex);
        }
    }
}
