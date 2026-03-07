using UnityEngine;

public class TrashController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Garbage"))
        {
            GameManager.instance.AddGarbage(); 
            Destroy(collision.gameObject);
        }
    }
}
