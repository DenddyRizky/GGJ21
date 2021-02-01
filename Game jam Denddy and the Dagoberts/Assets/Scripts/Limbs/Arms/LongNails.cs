using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNails : Arm
{

    private enum State
    {
        Normal,
        Dashing,
    }

    Rigidbody2D player;

    public LayerMask enemyLayers;
    private int angle = 5;
    public float dashSpeed;
    public float originalDashSpeed;
    public float maxDashDist;
    private Vector2 moveDirection;
    public Vector2 size;
    private Vector2 mouseDir;
    private Vector3 worldMousePos;
    private State state;

    private void Awake()
    {
        state = State.Normal;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        attackCD = false;
        cooldown = cooldownTime - attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        worldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = (Vector2)(worldMousePos - transform.position);

        mouseDir.Normalize();
        attackPoint.position = (Vector2)transform.position + mouseDir;

        CheckAttackCD();

        if (Input.GetButtonDown("Fire1") & !attackCD)
            Attack();

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

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                break;
            case State.Dashing:
                player.velocity = -moveDirection * dashSpeed;
                break;
        }
    }

    void Attack()
    {
        attackCD = true;
        size = mouseDir;
        Debug.Log(size);

        Debug.Log("ATTACK");
        Collider2D[] hitEnemies = Physics2D.OverlapCapsuleAll(attackPoint.position, size, CapsuleDirection2D.Horizontal, angle, enemyLayers);

        //Dash();

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT");
        }
    }

    void Dash()
    {
        moveDirection = (transform.position - worldMousePos);
        moveDirection.Normalize();
        dashSpeed = originalDashSpeed;
        state = State.Dashing;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 worldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDir = (Vector2)(worldMousePos - transform.position);

        mouseDir.Normalize();
        size = mouseDir;
        Gizmos.DrawWireCube(attackPoint.position, size);
    }
}
