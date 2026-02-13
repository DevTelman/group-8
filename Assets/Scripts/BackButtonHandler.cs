using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
