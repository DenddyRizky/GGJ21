using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollerskates : Leg

{
    private enum State
    {
        Normal,
        Dashing,
    }

    public Rigidbody2D player;
    private Vector3 moveDirection;
    public float dashSpeed;
    public float originalDashSpeed;
    public float maxDashDist;
    private State state;

    Vector3 mousePos;
    Vector3 mouseDir;

    private void Awake()
    {
        state = State.Normal;
    }
    // Start is called before the first frame update
    void Start()
    {
        spd = 5;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection = (transform.position - mousePos);
            moveDirection.z = 0;
            moveDirection.Normalize();
            dashSpeed = originalDashSpeed;
            state = State.Dashing;
        }

        switch (state)
        {
            case State.Normal:

                break;
            case State.Dashing:
                float dashSpeedMultiplier = 5f;
                dashSpeed -= dashSpeed * dashSpeedMultiplier * Time.deltaTime;

                float dashSpeedMinimum = 50f;
                if (dashSpeed < dashSpeedMinimum)
                    state = State.Normal;
                break;

        }

    }

    void FixedUpdate()
    {

        switch (state)
        {
            case State.Normal:
                break;
            case State.Dashing:
                player.velocity = -moveDirection * dashSpeed;
                break;
        }

        mouseDir = mousePos - transform.position;
        
        Debug.DrawRay(transform.position, mouseDir, Color.green);

        //if (dash)
        //{               
        //    Dash(x, y);
        //    dash = false;
        //}

    }

    void Dash(float x, float y)
    {

        //player.velocity = Vector2.zero;        
        //player.velocity = Vector2.MoveTowards(transform.position, -moveDirection * dashSpeed, maxDashDist);
        //
        //Debug.Log("We goin");
        //Debug.Log((-moveDirection * dashSpeed));
    }
}
