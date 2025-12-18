using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Clickfunctional : MonoBehaviour
{
    //public float jumpForce = 20f;
    //private Rigidbody2D rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    if (Mouse.current.leftButton.wasPressedThisFrame)
    //    {
    //        rb.linearVelocity = Vector2.zero;
    //        Vector2 dir = new Vector2(1, 1).normalized;
    //        rb.AddForce(dir * jumpForce, ForceMode2D.Impulse);
    //    }
    //}
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction;

        // Եթե հպում կա (touch կամ mouse)
        if (Input.GetMouseButton(0))
        {
            // 45° վերև
            direction = new Vector2(1f, 1f).normalized;
        }
        else
        {
            // 45° ներքև
            direction = new Vector2(1f, -1f).normalized;
        }

        // Շարժում Rigidbody-ով
        rb.linearVelocity = direction * speed;
    }


}
