using UnityEngine;

public class Star : MonoBehaviour
{
    private StarManager starManager;
    private bool collected = false;

    void Start()
    {
        starManager = FindObjectOfType<StarManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.transform.root.CompareTag("Player"))
        {
            collected = true;
            starManager.CollectStar();
            Destroy(gameObject);
        }
    }
}
