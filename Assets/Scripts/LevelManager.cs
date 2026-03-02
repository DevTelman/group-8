using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void GoToTutorialScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToTLevel1Scene()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToBossLevelScene()
    {
        SceneManager.LoadScene(5);
    }

    public void GoToTLevel2Scene()
    {
        SceneManager.LoadScene(6);
    }
}
