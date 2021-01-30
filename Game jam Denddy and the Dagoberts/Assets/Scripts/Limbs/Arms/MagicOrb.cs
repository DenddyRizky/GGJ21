using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : Arm
{
    public Camera cam;
    public GameObject firePoint;
    public LineRenderer lr;
    public bool enemy;
    public float maxLength;
    public LayerMask beamLayer;
    private Vector2 point;

    // Start is called before the first frame update
    void Start()
    {
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
        if (!enemy)
        {
            point = firePoint.transform.position;
             target = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            point = this.gameObject.transform.position;
        }
        
        
        Vector2 angle = new Vector2((target.x - point.x), (target.y - point.y));
        angle.Normalize();

        Vector2 maxRangeBeam = point + (angle * maxLength);

        lr.SetPosition(0, point);

        Vector2 angleToMouse = maxRangeBeam - target;
        Vector2 angleToPoint = maxRangeBeam - point;
        angleToMouse.Normalize();
        angleToPoint.Normalize();

        if (angleToMouse != angleToPoint)
        {
            lr.SetPosition(1, maxRangeBeam);
        } else
        {
            lr.SetPosition(1, target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point, maxLength);
    }
}
