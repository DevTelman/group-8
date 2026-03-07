using UnityEngine;

public class Star : MonoBehaviour
{
    private bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;
            GameManager.instance.AddStar();
            FindObjectOfType<StarManager>()?.CollectStar();
            Destroy(gameObject);
        }
    }
}
