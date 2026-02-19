using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveGame : MonoBehaviour
{
    public void LeaveLeveleGame()
    {
        SceneManager.LoadScene(3);
    }
}
