﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float diagmovevar = 0.7f;
    private Stats spd;
    private float runSpeed = 3f;

    public Leg leg;

    void Start()
    {
        leg = GetComponent<Leg>();
        body = GetComponent<Rigidbody2D>();
        spd = GetComponent<Stats>();
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
            leg.ActiveLegs[1] = 1;
            Destroy(collision.gameObject);
        }
    }
}
