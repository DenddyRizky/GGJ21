using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArm : Arm
{
    public Rigidbody2D projectile;
    public float attackVelocity;

    // Start is called before the first frame update
    void Start()
    {
        attackCD = false;
        attackVelocity = 500.0f;
        cooldown = cooldownTime - attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttackCD();

        if (Input.GetButtonDown("Fire1") &! attackCD)
            Attack();
    }

    void Attack()
    {
        attackCD = true;
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = transform.position;

        Rigidbody2D pr = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
        pr.gameObject.SetActive(true);

        Vector2 shootDirection = (target - position);
        Debug.Log(shootDirection);
        shootDirection.Normalize();

        pr.AddForce(shootDirection * attackVelocity);
    }
}
