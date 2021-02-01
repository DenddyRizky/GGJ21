using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArm : Arm
{
    public Rigidbody2D projectile;

    public bool enemy;
    private float attackVelocity;
    public Vector2 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        attackCD = false;
        attackVelocity = 300.0f;
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
            target = camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        Vector2 position = transform.position;
        
        Rigidbody2D pr = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;

        Vector2 shootDirection = (target - StartPosition);

        shootDirection = (target - StartPosition);
        
        shootDirection.Normalize();

        pr.AddForce(shootDirection * attackVelocity  * ((Vector2.Angle(target, this.transform.position) - 45) * 0.03f) );
       
            
    }
}
