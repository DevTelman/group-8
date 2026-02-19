using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    public void GoToTLevel1Scene()
    {
        SceneManager.LoadScene(3);
    }
}
