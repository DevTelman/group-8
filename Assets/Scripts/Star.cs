using UnityEngine;

public class Star : MonoBehaviour
{
    private bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.transform.root.CompareTag("Player"))
        {
            collected = true;
            FindObjectOfType<StarManager>()?.CollectStar();
            GameManager.instance.AddStar();
            Destroy(gameObject);
        }
    }
}
