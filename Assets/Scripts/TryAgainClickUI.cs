using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TryAgainClickUI : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("TRY AGAIN CLICKED");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
