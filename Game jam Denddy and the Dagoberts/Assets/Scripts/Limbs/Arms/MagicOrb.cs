using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : Arm
{
    public Camera cam;
    public GameObject firePoint;
    public LineRenderer lr;
    public int maxLength;
    public bool enemy;

    // Start is called before the first frame update
    void Start()
    {
        maxLength = 10;
        attack = 10.0f;
        if (GetComponentInParent<EnemyControllerScript>() != null)
        {
            lr = GetComponent<LineRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && !enemy)
            Attack();

        if (Input.GetButtonUp("Fire1") && !enemy)
            lr.enabled = false;
    }
    public void Attack(Vector2 target = default(Vector2), bool Enemy = default(bool))
    {
        lr.enabled = true;
        if (enemy)
        {
             target = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            firePoint = this.gameObject;
        }
        

        lr.SetPosition(0, firePoint.transform.position);
        
        lr.SetPosition(1, target);
        
    }
}
