using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject limb;

    private Stats spd;
    public Arm arm;
    public Head head;
    public Leg leg;
    public Torso torso;
    public bool fallen;

    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;
    private float runSpeed = 3f;


    void Start()
    {
        //runSpeed = 3f;
        head = GetComponent<Head>();
        leg = GetComponent<Leg>();
        body = GetComponent<Rigidbody2D>();
        spd = GetComponent<Stats>();
        arm = GetComponent<Arm>();
        torso = GetComponent<Torso>();
        fallen = false;
    }

    void Update()
    {
        if (!fallen)
        {
            if (spd.spd != 0)
            {
                runSpeed = spd.spd;
            }

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if(horizontal != 0 || vertical != 0)
            {
                AudioManager.PlaySound(AudioManager.Sound.gunshot);
            }
        }

    }

    private void FixedUpdate()
    {
        if (!fallen)
        {
            if (horizontal != 0 && vertical != 0 & !fallen)
            {
                horizontal *= diagmovevar;
                vertical *= diagmovevar;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        else
        {
            body.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Sneakers")
        {
            leg.activeLegs[1] = 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "RollerSkates")
        {
            leg.activeLegs[2] = 2;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "SpikeBoots")
        {
            leg.activeLegs[3] = 3;
            Destroy(collision.gameObject);
        }


        if(collision.gameObject.name == "ChitinArmour")
        {
            torso.activeTorso[0] = 0;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "TentacleBody")
        {
            torso.activeTorso[1] = 1;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.name == "AngelWings")
        {
            torso.activeTorso[2] = 2;
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.name == "Sharingans")
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

}
