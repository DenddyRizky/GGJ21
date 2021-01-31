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

    public bool enemy;
    private bool dashCooldown;

    public Rigidbody2D player;
    private Vector3 moveDirection;

    public float cooldown;
    private float cooldownTime;
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
        cooldownTime = cooldown;
        spd = 5;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckDashCooldown();
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space) && !dashCooldown && !enemy)
        {
            Dash();
        }

        switch (state)
        {
            case State.Normal:

                break;
            case State.Dashing:
                float dashSpeedMultiplier = 5f;
                dashSpeed -= dashSpeed * dashSpeedMultiplier * Time.deltaTime;

                float dashSpeedMinimum = 30f;
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
                GetComponentInParent<Rigidbody2D>().velocity = -moveDirection * dashSpeed;
                break;                
        }

        mouseDir = mousePos - transform.position;
        
        //Debug.DrawRay(transform.position, mouseDir, Color.green);

        //if (dash)
        //{               
        //    Dash(x, y);
        //    dash = false;
        //}

    }

    public void Dash(Vector3 target = default(Vector3), bool enemy = default(bool))
    {
        this.enemy = enemy;
        dashCooldown = true;
        if (!enemy)
            target = mousePos;
        Debug.Log("am enem, am dash");
        moveDirection = (transform.position - target);
        moveDirection.z = 0;
        moveDirection.Normalize();
        dashSpeed = originalDashSpeed;
        state = State.Dashing;
    }

    void CheckDashCooldown()
    {
        if(dashCooldown && cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                dashCooldown = false;
                cooldown = cooldownTime;
            }
        }
    }
}
