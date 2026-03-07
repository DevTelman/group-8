using UnityEngine;

public class TrashController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Garbage"))
        {
            if (collision.gameObject.activeInHierarchy)
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.AddGarbage();
                }
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }
}
