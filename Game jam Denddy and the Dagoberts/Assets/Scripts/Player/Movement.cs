using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject limb;

    private Stats spd;
    public Arm arm;
    public Leg leg;
    public Torso torso;

    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;
    private float runSpeed = 3f;


    void Start()
    {
        leg = GetComponent<Leg>();
        body = GetComponent<Rigidbody2D>();
        spd = GetComponent<Stats>();
        arm = GetComponent<Arm>();
        torso = GetComponent<Torso>();
    }

    void Update()
    {
        if (spd.spd != 0)
        {
            runSpeed = spd.spd;
        }        

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Sneakers")
        {
            leg.activeLegs[1] = 1;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "RollerSkates")
        {
            leg.activeLegs[2] = 2;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "SpikeBoots")
        {
            leg.activeLegs[3] = 3;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.name == "ChitinArmour")
        {
            torso.activeTorso[1] = 1;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "TentacleBody")
        {
            torso.activeTorso[2] = 2;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "AngelWings")
        {
            torso.activeTorso[3] = 3;
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
