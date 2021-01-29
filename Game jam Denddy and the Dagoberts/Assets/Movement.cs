using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    public Rigidbody2D projectile;

    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Attack();
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= diagmovevar;
            vertical *= diagmovevar;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arm")
        {
        }
    }
}
