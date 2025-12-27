using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Clickfunctional : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    public float direction1 = 110f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction;
        if (Input.GetMouseButton(0))
        {

            direction = new Vector2(1f, 1f).normalized;
        }
        else
        {

            direction = new Vector2(1f, -1f).normalized;
        }
      
        rb.linearVelocity = direction * speed;
        bool isPressed =
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed) ||
            (Mouse.current != null && Mouse.current.leftButton.isPressed);

        if (isPressed)
            direction = new Vector2(1f, 1f).normalized;
        else
            direction = new Vector2(1f, -1f).normalized;

        rb.linearVelocity = direction * speed;

      
        if (rb.linearVelocity.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            rb.rotation = angle - direction1;
        }
    }
}
