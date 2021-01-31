using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArm : Arm
{
    public Rigidbody2D projectile;
    public GameObject player;
    public bool enemy;
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

        if (Input.GetButtonDown("Fire1") && !attackCD && !enemy)
            Attack();

    }

    public void Attack(Vector2 target = default(Vector2), bool Enemy = default(bool) ) {
        this.enemy = Enemy;
        attackCD = true;

        if(!Enemy){
            target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        Vector2 position = transform.position;
        
        Rigidbody2D pr = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;

        Vector2 shootDirection = (target - position);
        
        shootDirection.Normalize();

        pr.AddForce(shootDirection * attackVelocity);
    }
}
