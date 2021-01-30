using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : Arm
{
    public Camera cam;
    public GameObject firePoint;
    public LineRenderer lr;
    public int maxLength;

    // Start is called before the first frame update
    void Start()
    {
        maxLength = 10;
        attack = 10.0f;
        attackVelocity = 100.0f;
        spread = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
            Attack();

        if (Input.GetButtonUp("Fire1"))
            lr.enabled = false;
    }
    void Attack()
    {
        lr.enabled = true;
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        lr.SetPosition(0, firePoint.transform.position);
        lr.SetPosition(1, mousePos);
    }
}
