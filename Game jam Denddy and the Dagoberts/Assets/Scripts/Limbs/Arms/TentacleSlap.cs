using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSlap : Arm
{
    public float attackRange;
    public LayerMask enemyLayers;
    Vector3 worldMousePos;
    Vector2 mouseDir;

    private void Start()
    {
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
    }

    void Attack()
    {
        attackCD = true;
        Debug.Log("ATTACK");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
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
