using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlappyHand : Arm
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    Vector3 worldMousePos;
    Vector2 mouseDir;

    // Update is called once per frame
    void Update()
    {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = (Vector2)(worldMousePos - transform.position);

        mouseDir.Normalize();
        attackPoint.position = (Vector2)transform.position + mouseDir;

        if (Input.GetButtonDown("Fire1"))
            Attack();
    }
    void Attack()
    {
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
