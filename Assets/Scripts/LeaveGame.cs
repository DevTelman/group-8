using UnityEngine;
using UnityEngine.SceneManagement;
public class LeaveGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LeaveLeveleGame()
    {
        SceneManager.LoadScene(3); // Բեռնում է 4-րդ սցենան
    }
}
