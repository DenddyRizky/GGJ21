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
        attack = 10.0f;
        attackVelocity = 500.0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !enemy)
            Attack();
    }

    public void Attack(Vector2 target = default(Vector2), bool Enemy = default(bool) ) {
        this.enemy = Enemy;
        if(!Enemy){
            target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        Rigidbody2D pr = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;

        Vector2 shootDirection = (target - (position * -1));
        Debug.Log(shootDirection);
        shootDirection.Normalize();

        pr.AddForce(shootDirection * attackVelocity);
    }
}
