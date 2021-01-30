using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNails : Arm
{
    Rigidbody2D body;
    public Transform attackPoint;
    public int attackRange = 5;
    public LayerMask enemyLayers;
    private int angle = 5; //
    public Vector2 size;
    private Vector2 mouseDir;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = (Vector2)(worldMousePos - transform.position);

        mouseDir.Normalize();
        attackPoint.position = (Vector2)transform.position + mouseDir;

        if (Input.GetButtonDown("Fire1"))
            Attack();
    }

    void Attack()
    {
        size = mouseDir;
        Debug.Log(size);

        Debug.Log("ATTACK");
        Collider2D[] hitEnemies = Physics2D.OverlapCapsuleAll(attackPoint.position, size, CapsuleDirection2D.Horizontal, angle, enemyLayers);

        body.AddForce(mouseDir * 500);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDir = (Vector2)(worldMousePos - transform.position);

        mouseDir.Normalize();
        size = mouseDir;
        Gizmos.DrawWireCube(attackPoint.position,size);
    }
}
