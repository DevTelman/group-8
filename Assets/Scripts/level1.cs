using UnityEngine;
using UnityEngine.SceneManagement;
public class level1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoToTLevel1Scene()
    {
        SceneManager.LoadScene(3);
    }
}
