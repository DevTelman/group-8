using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public class WinManager : MonoBehaviour
    {
        public static bool levelCompleted = false;
    }
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinManager.levelCompleted = true;
            SceneManager.LoadScene("the hub");
        }
    }
}