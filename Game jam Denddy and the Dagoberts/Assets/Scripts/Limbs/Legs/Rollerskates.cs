using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollerskates : Leg

{
    Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        spd = 5;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Dash(player);
        }

    }

    void Dash(Rigidbody2D player)
    {
        
    }
}
