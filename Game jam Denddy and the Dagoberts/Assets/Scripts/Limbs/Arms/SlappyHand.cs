using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlappyHand : Arm
{
    public float attackRange;
    public LayerMask enemyLayers;
    Vector3 worldMousePos;
    Vector2 mouseDir;
    bool enemy;

    // Update is called once per frame
    void Update()
    {
        enemy = false;

        if (Input.GetButtonDown("Fire1"))
            Attack();
    }
    public void Attack(Vector2 target = default(Vector2), bool Enemy = default(bool))
    {
        this.enemy = Enemy;
        if (!enemy)
        {
            worldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            mouseDir = (Vector2)(worldMousePos - transform.position);

            mouseDir.Normalize();
            attackPoint.position = (Vector2)transform.position + mouseDir;
        }
        else
        {
        }
        

        Debug.Log("ATTACK");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
