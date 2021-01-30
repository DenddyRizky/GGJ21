using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    public Rigidbody2D projectile;
    public GameObject limb;
    public Arm arm;

    public bool gunArm = false;

    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;

    public float runSpeed = 10.0f;

    void Start()
    {
        arm = GetComponent<Arm>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
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
        if (collision.gameObject.name == "GunArm")
        {
            arm.types[0] = 1;
        }
        else if (collision.gameObject.name == "MagicOrb") arm.types[1] = 2;
        else if (collision.gameObject.name == "Tentacle") arm.types[2] = 3;
        else if (collision.gameObject.name == "Nails") arm.types[3] = 4;
    }
}
