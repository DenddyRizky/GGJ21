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
<<<<<<< HEAD
=======

    Animator anim;
>>>>>>> main

    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;
    private float runSpeed = 3f;


    void Start()
    {
<<<<<<< HEAD
        //runSpeed = 3f;
        head = GetComponent<Head>();
=======
        fallen = false;
>>>>>>> main
        leg = GetComponent<Leg>();
        body = GetComponent<Rigidbody2D>();
        spd = GetComponent<Stats>();
        arm = GetComponent<Arm>();
        torso = GetComponent<Torso>();
<<<<<<< HEAD
        fallen = false;
=======
        anim = GetComponent<Animator>();
>>>>>>> main
    }

    void Update()
    {
        if (!fallen)
        {
            if (spd.spd != 0)
            {
                runSpeed = spd.spd;
<<<<<<< HEAD
            }

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if(horizontal != 0 || vertical != 0)
            {
                AudioManager.PlaySound(AudioManager.Sound.gunshot);
            }
        }

=======
            }        

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }


        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
>>>>>>> main
    }

    private void FixedUpdate()
    {
        if (!fallen)
        {
<<<<<<< HEAD
            if (horizontal != 0 && vertical != 0 & !fallen)
=======
            if (horizontal != 0 && vertical != 0 &! fallen)
>>>>>>> main
            {
                horizontal *= diagmovevar;
                vertical *= diagmovevar;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
<<<<<<< HEAD
        }
        else
        {
            body.velocity = Vector2.zero;
        }

=======
        } else
        {
            body.velocity = Vector2.zero;
        }
>>>>>>> main
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

<<<<<<< HEAD

        if(collision.gameObject.name == "ChitinArmour")
        {
            torso.activeTorso[0] = 0;
=======
        if (collision.gameObject.name == "ChitinArmour")
        {
            torso.activeTorso[0] = 1;
>>>>>>> main
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "TentacleBody")
        {
<<<<<<< HEAD
            torso.activeTorso[1] = 1;
=======
            torso.activeTorso[1] = 2;
>>>>>>> main
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "AngelWings")
        {
<<<<<<< HEAD
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
=======
            torso.activeTorso[2] = 3;
>>>>>>> main
            Destroy(collision.gameObject);
        }

    }

}
