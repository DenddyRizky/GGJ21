using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject limb;
    public Arm arm;
    public Head head;
    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;
    private Stats spd;
    private float runSpeed = 3f;

    public Leg leg;

    void Start()
    {
        //runSpeed = 3f;
        head = GetComponent<Head>();
        leg = GetComponent<Leg>();
        body = GetComponent<Rigidbody2D>();
        spd = GetComponent<Stats>();
        arm = GetComponent<Arm>();
    }

    void Update()
    {
//        if (spd.spd != 0)
//        {
//            runSpeed = spd.spd;
//        }        
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
        if (collision.gameObject.name == "Sneakers")
        {
            leg.ActiveLegs[1] = 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "RollerSkates")
        {
            leg.ActiveLegs[2] = 2;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "SpikeBoots")
        {
            leg.ActiveLegs[3] = 3;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Sharingans")
        {
            head.ActiveHeads[1] = 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "ScaryFace")
        {
            head.ActiveHeads[2] = 2;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Teeth")
        {
            head.ActiveHeads[3] = 3;
            Destroy(collision.gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == "GunArm")
    //    {
    //        arm.types[0] = 1;
    //    }
    //    else if (collision) arm.types[1] = 2;
    //}
}
