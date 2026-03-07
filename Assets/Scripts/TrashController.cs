using UnityEngine;

public class TrashController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Garbage"))
        {
            // Աղբը հաշվում ենք միայն եթե այն դեռ ակտիվ է
            if (collision.gameObject.activeInHierarchy)
            {
                GameManager.instance.AddGarbage();
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }
}
